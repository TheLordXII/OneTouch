// Global
var express = require('express');
var app = express();
var router = express.Router();
var bodyparser = require('body-parser');
var http = require('http');
var fs = require('fs'); 
var https = require('https');
var mqtt = require('mqtt');


var privatekey = fs.readFileSync('C:\\Projects\\REST\\cert\\cert.key', 'utf8');
var certificate = fs.readFileSync('C:\\Projects\\REST\\cert\\cert.crt', 'utf8');
var credentials = {key:privatekey, cert:certificate};

//mqtt client
var mqttclient = mqtt.connect('mqtt://onetouchnextgen.tech');

mqttclient.on('connect', function(){
    mqttclient.subscribe('machine/Drink', function(err){
        if (!err) mqttclient.publish('machine/Drink', 'lol123'); 
    });
});

//body-parser magie 
app.use(bodyparser.urlencoded({extended:true}));
app.use(bodyparser.json());

// SQL config
var sql = require("mssql");

// config for your database
var config = {
    user: 'sa',
    password: 'OneTouch7',
    server: 'h2883569.stratoserver.net', 
    database: 'OneTouch',
    port: 1434
};

//starting server
// var server = app.listen(5000, function () {
//     console.log('Server is running..');
// });

var httpsServer = https.createServer(credentials, app);
httpsServer.listen(5000, function(){
    console.log('Server is running');
});  

//Router is working
router.use(function(req, res, next) {
    console.log('Router use macht was.');
    next();
});

//Test wether routes are working.
router.get('/', function(req, res) {

    res.json({message: 'Welcome to OneTouch API!'});
});

//REST of the Routes
app.use('/api', router);
// ./api/drinks Routedefinition
router.route('/drinks')
    //get Drinks from the Database
    .get(function(req, res) {
        console.log('/drinks get geroutet')
        sql.connect(config, function (err) {
            if (err) console.log(err);
            //create request object
            var request = new sql.Request();
            //query to the database to get respond
            request.query('Select * From Drink', function(err, result) {
            
                if (err) console.log(err)
            
                //send records as a response
                res.json({ Data: result.recordset});
            });
        });
    })

// router.route('/insertdrink/')
//     .post(function(req, res) {
//         console.log('/drinks put geroutet');
//         sql.connect(config, function (err) {
//             if (err) console.log(err);
//             //create request object
//     });

router.route('/drink/bestdrinkers')
    //get Drinkers Tier List
    .get(function(req, res){
        console.log('/drinks/bestdrinkers geroutet')
        //sql connection
        sql.connect(config, function(err) {
            if(err) console.log(err);
        
        //building request
        var request = new sql.Request();
        request.query('SELECT Benutzername,Drinks_Taken FROM [dbo].[User] ORDER BY Drinks_Taken DESC', function(err, result){
            if (err) console.log(err)
            //send recordset as result
            res.json({ Data: result.recordset});
        });
    });
});

router.route('/drink/bestdrinks')
    //get Best Drinks Tier List
    .get(function(req, res){
        console.log('/drinks/bestdrinks geroutet')
        //sql connection
        sql.connect(config, function(err) {
            if(err) console.log(err);
        
        //building request
        var request = new sql.Request();
        request.query('SELECT [Name],[Times_Taken] FROM [dbo].[Drink] ORDER BY Times_Taken DESC', function(err, result){
            if (err) console.log(err)
            //send recordset as result
            //console.log(result.recordset);
            res.json({ Data: result.recordset});
        });
    });
});

router.route('/drinks/:value')
    //get one drink from the database
    .get(function(req, res) {
        console.log('/drinks/value geroutet')
        //sql connection
        sql.connect(config, function (err) {
            if (err) console.log(err);
        
        //bulding request
        var request = new sql.Request();
        //input the url-value as parameter into the sql-statement
        request.input('drinkid', sql.Int , req.params.value);
        request.query('SELECT * FROM Drink WHERE DrinkID = @drinkid', function(err, result) {
            if (err) console.log(err)
            //send recordset as the result
            console.log(result.recordset);
            res.json({ Data: result.recordset});
            
        });
    });


});

router.route('/takedrink/drinkid=:did&userid=:uid')
    .put(function(req, res) {
        console.log('/drinks/taken geroutet');
        //sql connection
        sql.connect(config, function (err) {
            if (err) console.log(err);
        
        //bulding request
        var request = new sql.Request();
        //input the url-value as parameter into the sql-statement
        request.input('did', sql.Int , req.params.did);
        request.input('uid', sql.Int, req.params.uid);

        request.query('UPDATE Drink SET Times_Taken = Times_Taken + 1 WHERE DrinkID = @did; UPDATE [dbo].[User] SET Drinks_Taken = Drinks_Taken + 1 WHERE UserID = @uid;', function(err, result) {
            if (err) console.log(err)
            //send message as the result
            res.json({message:'Successful'});
            });
        });
        
    });

router.route('/ingredientlist/:value')
    //get ingredientlist from the database
    .get(function(req, res) {
        console.log('/ingredientlist geroutet')
        //sql connection
        sql.connect(config, function (err) {
            if (err) console.log(err);
        
        //bulding request
        var request = new sql.Request();
        //input the url-value as parameter into the sql-statement
        request.input('drinkid', sql.Int , req.params.value);
        request.query('SELECT Ingredient.Name, DrinkToIngredient.How_Much FROM DrinkToIngredient RIGHT JOIN Ingredient ON Ingredient.IngredientID = DrinkToIngredient.IngredientID WHERE DrinkID = @drinkid', function(err, result) {
            if (err) console.log(err)
            //send recordset as the result
            console.log(result.recordset);
            res.json({ Data: result.recordset});
            
        });
    });
    });

router.route('/user')
    .get(function(req, res){
        //gets all users from Database
        console.log('/user geroutet');
        sql.connect(config, function(err){
            if (err) console.log(err);

        var request = new sql.Request();
        request.query('SELECT * FROM [dbo].[User]', function(err, result){
            if(err) console.log(err)

            res.json({ Data: result.recordset});
        });
        });
    });

router.route('/user/login/username=:user&password=:pwd')
    .get(function(req, res) {
        //checks if passwordcredentials are valid
        console.log('/user/login geroutet');
        //sql connection
        sql.connect(config, function (err) {
            if (err) console.log(err);
        
        //building request
        var request = new sql.Request();
        //user input into sql statement
        request.input('user', sql.NVarChar, req.params.user);
        request.input('password', sql.NVarChar, req.params.pwd);
        //sql statement to database
        request.query('SELECT CASE WHEN EXISTS (SELECT * FROM [dbo].[User] WHERE Benutzername = @user AND Password = @password) THEN 0 ELSE 1 END AS RESULT', function(err, result) {
            //error handling
            console.log(result.recordset)
            if (result.recordset[0].RESULT == 1) {
                res.status(400).json({message:'Invalid credentials'});
            } else {
            //all good
            res.status(200).json({Benutzername: req.params.user});
            }
        });
    });

router.route('/newuser/username=:user&password=:pwd&name=:name&vorname=:vorname&gebdate=:date')
    .post(function(req, res, next){
        //puts a new user in the Database
        console.log('/newuser geroutet');
        //sql connection
        sql.connect(config, function(err){
            if(err) console.log(err);

        //building request
        var request = new sql.Request();
        request.input('username', sql.NVarChar, req.params.user);
        request.input('password', sql.NVarChar, req.params.pwd);
        request.input('name', sql.NVarChar, req.params.name);
        request.input('vorname', sql.NVarChar, req.params.vorname);
        request.input('gebDate', sql.Date, req.params.date);

        request.query('INSERT INTO [dbo].[User] ([Name],[Vorname],[Benutzername],[GebDatum],[Is_Admin],[Drinks_Taken],[Password]) VALUES (@name,@vorname,@username,@gebDate,0,0,@password)', function(err, result) {
            if(err) console.log(err);

        res.json({message: 'Successful'});
        });
        });

    });

router.route('/user/deleteuser/:value')
    .delete(function(req, res){
        //deletes a user from the Database
        console.log('/user/deleteuser geroutet');
        //sql connection
        sql.connect(config, function(err){
            if(err) console.log(err);

        //building request
        var request = new sql.Request();
        request.input('uid', sql.Int, req.params.value);
        request.query('DELETE FROM [dbo].[User] WHERE UserID = @uid', function(res, err){
            if (err) console.log(err);

        res.json({ message: 'User deleted'});
        });
        });
    });

});

router.route('/mqtt/queue/:value')
    .post(function(req, res, next){
        //sends Drinkrequest to the Machine
        console.log('/mqtt/queue/value geroutet');

        //sql connection
        sql.connect(config, function(err){
            if(err) console.log(err);
        
        //building request
        var request = new sql.Request();
        request.input('did', sql.Int, req.params.value);
        request.query('SELECT Ingredient.Name, DrinkToIngredient.How_Much FROM Drink Left JOIN DrinkToIngredient ON Drink.DrinkID = DrinkToIngredient.DrinkID Left JOIN Ingredient ON DrinkToIngredient.IngredientID = Ingredient.IngredientID WHERE Drink.DrinkID = @did', function(err, result){
            if (err) console.log(err);

        console.log(result.recordset);

        //hier kommt mqtt wooohooo
        mqttclient.publish('machine/Drink', JSON.stringify(result.recordset));
        res.json({ Data: result.recordset});
        });
        });
    });