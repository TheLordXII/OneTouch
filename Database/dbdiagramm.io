// Creating tables
Table Benutzer{
  id int [pk, increment] // auto-increment
 LastName varchar
 FirstName varchar
 Username varchar
 password varchar
 GebDatum date
 is_Admin boolean
 DrinksTaken int
 friends int [ref: < Friends.friend1, ref: < Friends.friend2]
}

Table Drinks{
  id int [pk, increment]
  DrinkName varchar
  Description varchar
  Ingredients int [ref: < DToI.DID]
  TimesTaken int
  creator int 
}

Table DToI {
  DID int [pk]
  IID int [pk]
 }
 
Table Ingredients{
  id int[pk, increment] 
  Name varchar
  PumpNr int
}

Table Friends{
  friend1 int [pk]
  friend2 int [pk]
}

// Creating references
// You can also define relaionship separately
// > many-to-one; < one-to-many; - one-to-one
Ref: Benutzer.id < Drinks.creator
ref: Ingredients.id < DToI.IID
