Consultorio Seguros

# Requerimientos

## Frontend
* Angular CLI: 18.2.0
* Node: 20.16.0
* Package Manager: npm 10.8.1
* Visual Studio Code

## Backend
* .NET Core/SDK: 8.0.400
* Visual Studio 2022

# Instrucciones

## Frontend
* Instalar el proyecto de Angular "consultorio-seguros". Usar "npm install" para instalar el proyecto y luego "ng serve" para correr el proyecto
* El proyecto usará el puerto 4200: `http://localhost:4200/`

## Backend
* La solución es la carpeta "ConsultorioSeguros"

## Base de datos
* Levantar la base de datos ejecutando el script "ConsultorioSeguros_DB.sql" que se encuentra en la carpeta "SQL_DB"
* Para probar la asignación masiva de registros cuando se carga un archivo .txt se deberá ingresar criterios a la tabla "CriteriosAsignacion", se podrá 
  hacer ejecutando el script "Insert_Criterios.sql".
* Para insertar los criterios deberá tener ingresado algún seguro en la tabla "Seguro", que se podrá hacer a través de la vista, para que funcione correctamente los criterios.
* El script para insertar tiene la siguiente estructura: 

	INSERT INTO CriteriosAsignacion (CodigoSeguro, EdadInicial, EdadFinal, Criterio)
	VALUES ('A12B', 20, null, 'Mayor'),
       	       ('R52V', 30, 40, 'Rango');

  -"CodigoSeguro" es un String único de máximo 20 caracteres y que será el código del seguro al que le quiere incluir un criterio para la asignación masiva automática.
  -"EdadIncial" es un Number y es requerido. Es la edad que se usará para aplicar los "Criterios": Mayor, Menor, Igual.
  -"EdadFinal" es un Number y es opcional (puede ser null). Solo se ingresará cuando se coloque un "Criterio" tipo "Rango".
  -"Criterio" es un String de máximo 10 caracteres que puede tener los siguientes valores: Mayor, Menor, Rango, Igual. 
  -El funcionamiento sería, si por ejemplo quisiera que el seguro con código "A12B" se asigne solo a Asegurados de mas de 24 años, entonces el script sería: 

	INSERT INTO CriteriosAsignacion (CodigoSeguro, EdadInicial, EdadFinal, Criterio)
	VALUES ('A12B', 24, null, 'Mayor');

* Para probar la carga masiva usar el archivo "asegurados.txt".


  

	
		








