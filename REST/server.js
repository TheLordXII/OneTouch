// Global
var express = require('express');
var app = express();
var router = express.Router();
var bodyparser = require('body-parser');
var http = require('http');
var fs = require('fs'); 
var https = require('https');

var privatekey = fs.readFileSync('C:\\Projects\\REST\\cert\\cert.key', 'utf8');
var certificate = fs.readFileSync('C:\\Projects\\REST\\cert\\cert.crt', 'utf8');
var credentials = {key:privatekey, cert:certificate};

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

router.route('/user/login/username=:user&password=:pwd')
    .get(function(req, res) {
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
});