import colander

class Drink(colander.MappingSchema):
    DrinkID=colander.SchemaNode(colander.Int())
    Name=colander.SchemaNode(colander.String())
    Description = colander.SchemaNode(colander.String())
    Times_Taken = colander.SchemaNode(colander.Int())
    Creator = colander.SchemaNode(colander.Int())

class DrinksList(colander.SequenceSchema):
    drink = Drink()

class DataList(colander.MappingSchema):
    Data = DrinksList()