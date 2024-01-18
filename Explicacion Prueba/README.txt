El objetivo de la prueba es el de crear una sencilla interfaz como la provista en las fotos, esta interfaz debe contener un botón que se conecte a la API del ElTiempo.com, toda la documentación se puede encontrar en su web: "https://www.el-tiempo.net/api".
De esta API se debe obtener una lista de provincias con la que se debe rellenar el Objeto Dropdown (desplegable), una vez relleno se debe poder seleccionar una de las provincias y obtener la información sobre el clima, que se mostrará en un panel diferente al anterior, este panel también tendra un botón que te permitirá volver al inicio.

Es necesario hacer uso de las corrutinas para recibir datos de la API, y para cualquier cosa que requiera de ello.

Anotaciones: 
Las provincias NO están en el orden de su ID, por ejemplo, A Coruña es la primera provincia que se coloca pero su ID no es la 01.
Los listeners NO se deben añadir manualmente desde el editor, deben ser creados en tiempo de ejecución desde un script, a no ser que realicen acciones muy sencillas (por ejemplo obj.SetActive()).
