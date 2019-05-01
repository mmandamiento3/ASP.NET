namespace Migraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creando_SP : DbMigration
    {
        public override void Up()
        {

            //Creamos los Procedimientos Almacenados
            CreateStoredProcedure("sp_Personas_Por_Edad",x=>new { Edad=x.Int()},
            @"Select Nombre,Edad,Sexo,Nacimiento
                FROM Personas WHERE Edad=@Edad"
                );


            CreateStoredProcedure("sp_Personas_Mayores_De_Edad", x => new { Edad = x.Int(18) },
         @"Select Nombre,Edad,Sexo,Nacimiento
                FROM Personas WHERE Edad>=@Edad"
             );


        }
        
        public override void Down()
        {
            DropStoredProcedure("sp_Personas_Por_Edad");
            DropStoredProcedure("sp_Personas_Mayores_De_Edad");
        }
    }
}
