# Utilizando la clase WindowsPrincipal con MonoDevelop

<p align="justify">
En este post Conceptos Básicos de seguridad en .NET (parte II) muestro un par de programas ejemplificando acerca de la utilización de la clase WindowsPrincipal. Esta clase representa la información de autenticación y de autorización de una entidad dentro del sistema.
</p>
<p align="justify">
Estos ejemplos pueden compilarse y ejecutarse en Linux, en este caso lo hice en un sistema operativo OpenSuse versión 11.1, con el compilador 2.6.7 y el runtime de mono versión 2.6.7, como se muestra en la siguiente imagen:
</p>
<img src="prop.png"/>
<p align="justify">
El primero de los dos ejemplos lo compilamos y lo ejecutamos mostrando el resultado como en la siguiente imagen:
</p>
<img src="simplePrinLin.png"/>
<p align="justify">
En la siguiente imagen mostramos el resultado si lo ejecutamos como el superusuario root.
</p>
<img src="simplePrin2.png"/>
<p align="justify">
En el caso del segundo ejemplo modificamos el código y cambiamos la interfaz de consola por una interfaz gráfica utilizando el diseñador GTK# de MonoDevelop, siguiendo los siguientes pasos:
</p>
<p align="justify">
1.Creamos una solución con un proyecto GTK# 2.0 en Monodevelop como en la siguiente imagen:
</p>
<img src="simplePrin3.png"/>
<p align="justify">
2.Modificamos la apariencia del formulario, agregamos dos botones btnEnter, btnClose y un textview nombrado txtInfo para que el formulario se vea como en la siguiente imagen:
</p>
<img src="simplePrin4.png"/>
<p align="justify">
3.Agregamos el método para el evento Clicked del botón btnEnterutilizando la pestaña señales en la ventana de propiedades, seleccionamos el evento y hacemos doble click para que MonoDevelop genere el código del método, como se muestra en las siguientes imagenes:
</p>
<img src="simplePrin5.png"/>
<img src="simplePrin6.png"/>
<p align="justify">
4.Agregamos las siguientes líneas al inicio del código de la clase MainWindow.cs , para utilizar los miembros de los ensamblados 
System.Security.Principal y System.Threading respectivamente.
</p>
<pre>
using System.Security.Principal;
using System.Threading;
</pre>
<p align="justify">
5.Dentro del método OnBtnEnterClicked del código generado por MonoDevelop para el evento del botón btnEnter, escribimos el siguiente código, el cual contiene toda la funcionalidad de nuestro programa:
</p>
<img src="OnBtnEnterClicked.png"/>
Nuestro programa entonces se vera como en la siguiente imagen:
<img src="simplePrin7.png"/>
<p align="justify">
6.Ahora creamos el código del evento Clicked para el botón btnClose de la misma forma que lo hicimos para el botón btnEnter, cuya acción será terminar el programa, por lo que escribimos el siguiente código dentro del método generado.
</p>
<pre>
protected virtual void OnBtnCloseClicked (object sender, System.EventArgs e)
{
Application.Quit();
}
</pre>
<p align="justify">
7.Para compilar el programa hacemos click en el submenú Construir todo debajo del la opción Construir en el menú principal. En caso de ejecutar el programa hacemos click en cualquiera de las opciones Ejecutar o Depurar bajo el menú Ejecutar en el menú principal.
</p>
<img scr="simplePrin8.png"/>
<p align="justify">
8.Si el programa se compila correctamente al ejecutarse mostrará el resultado como en la siguiente imagen:
</p>
<img src="simplePrin9.png"/>
<p align="justify">
9.Si ejecutamos el programa desde la terminal como superusuario nos mostrará el resultado como en la siguiente imagen:
</p>
<img src="simplePrin10.png"/>
<p align="justify">
Vemos en el resultado de la ejecucción que el metódo de autenticación es POSIX.
</p>
