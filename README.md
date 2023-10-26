# **GeoGuide - Game Design Document**
<p align="center"><img src="./imagenesGDD/geoguideTitulo.png"></p>

- [**GeoGuide - Game Design Document**](#geoguide---game-design-document)
	- [**1 - Ficha técnica**](#1---ficha-técnica)
	- [**2 - Descripción**](#2---descripción)
	- [**3 - Jugabilidad**](#3---jugabilidad)
		- [**3.1 - Mecánicas del jugador**](#31---mecánicas-del-jugador)
		- [**3.2 - Cámara**](#32---cámara)
		- [**3.3 - Mecánicas de gameplay**](#33---mecánicas-de-gameplay)
	- [**4 - Diseño de nivel**](#4---diseño-de-nivel)
		- [**4.1 - Organización de niveles por continentes**](#41---organización-de-niveles-por-continentes)
		- [**4.2 - Descripción del nivel introductorio**](#42---descripción-del-nivel-introductorio)
		- [**4.3 - Descripción de niveles posteriores (o imprevistos)**](#43---descripción-de-niveles-posteriores-o-imprevistos)
	- [**5 - Interfaz**](#5---interfaz)
		- [**5.1 - Mockup del HUD in-game**](#51---mockup-del-hud-in-game)
			- [**5.1.1 - Explicación de los elementos del HUD in-game y su funcionamiento**](#511---explicación-de-los-elementos-del-hud-in-game-y-su-funcionamiento)
		- [**5.2 - Mockup de la interfaz del menú inicial**](#52---mockup-de-la-interfaz-del-menú-inicial)
			- [**5.2.1 - Explicación de los elementos de la interfaz del menú inicial y su funcionamiento**](#521---explicación-de-los-elementos-de-la-interfaz-del-menú-inicial-y-su-funcionamiento)
		- [**5.3 - Mockup de la interfaz del menú de niveles/menú principal**](#53---mockup-de-la-interfaz-del-menú-de-nivelesmenú-principal)
			- [**5.3.1 - Explicación de los elementos de la interfaz del menú de niveles y su funcionamiento**](#531---explicación-de-los-elementos-de-la-interfaz-del-menú-de-niveles-y-su-funcionamiento)
		- [**5.4 - Mockup de la interfaz del menú de información**](#54---mockup-de-la-interfaz-del-menú-de-información)
			- [**5.4.1 - Explicación de los elementos de la interfaz del menú de información y su funcionamiento**](#541---explicación-de-los-elementos-de-la-interfaz-del-menú-de-información-y-su-funcionamiento)
		- [**5.5 - Mockup de la interfaz del menú de pausa**](#55---mockup-de-la-interfaz-del-menú-de-pausa)
			- [**5.5.1 - Explicación de los elementos de la interfaz del menú de pausa y su funcionamiento**](#551---explicación-de-los-elementos-de-la-interfaz-del-menú-de-pausa-y-su-funcionamiento)
		- [**5.6 - Mockup de la interfaz del menú de ajustes**](#56---mockup-de-la-interfaz-del-menú-de-ajustes)
			- [**5.6.1 - Explicación de los elementos de la interfaz del menú de ajustes y su funcionamiento**](#561---explicación-de-los-elementos-de-la-interfaz-del-menú-de-ajustes-y-su-funcionamiento)
		- [**5.7 - Mockup de la interfaz del menú de controles**](#57---mockup-de-la-interfaz-del-menú-de-controles)
			- [**5.7.1 - Explicación de los elementos de la interfaz del menú de controles y su funcionamiento**](#571---explicación-de-los-elementos-de-la-interfaz-del-menú-de-controles-y-su-funcionamiento)
	- [**6 - Estética**](#6---estética)
	- [**7 - Menús y flujo de juego**](#7---menús-y-flujo-de-juego)
	- [**8 - Historia y personaje principal**](#8---historia-y-personaje-principal)
	- [**9 - Recursos**](#9---recursos)
	- [**10 - Referencias**](#10---referencias)

## **1 - Ficha técnica**
- **Título**: *GeoGuide*
- **Género**: Juego serio de simulación
- **Público objetivo**: Estudiantes de 8 a 15 años interesados en el aprendizaje de Geografía, sin necesidad de una base previa, de forma dinámica y entretenida.
- **Rating**: PEGI 7
- **Plataforma**: PC (Windows)
- **Modos de juego**:
	- Un jugador.

## **2 - Descripción**
Juego casual, de simulación, enfocado en el aprendizaje y descubrimiento geográfico, en el que el jugador pilotará un avión transportando clientes por el mundo al destino que le pidan y aprenderá todo tipo de datos interesantes sobre los países visitados.

## **3 - Jugabilidad**
### **3.1 - Mecánicas del jugador**
<table>
	<tr>
		<th>Acciones</th>
		<th>Descripción</th>
		<th>Input</th>
	</tr>
	<tr>
		<td><b>Pilotar el avión</b></td>
		<td>En cada nivel el avión se moverá constantemente hacia delante con una velocidad constante inicial. El usuario podrá girarlo hacia la derecha e izquierda con A y D respectivamente y podrá cambiar su velocidad con la W(aumentar) y S(reducir).</td>
		<td>W A S D</td>
	</tr>
	<tr>
		<td><b>Aterrizar avión</b></td>
		<td>Cada país del mundo tendrá un <u><a href="#33---mecánicas-de-gameplay">aeropuerto</a></u>. Una vez se ha llegado al aeropuerto del país destino, el jugador podrá aterrizar pulsando el espacio. Una vez aterrizado se decidirá las <u><a href="#43---descripción-de-niveles-posteriores-o-imprevistos">estrellas</a></u> conseguidas.</td>
		<td>Barra espaceadora</td>
	</tr>
	<tr>
		<td><b>Cambio de velocidad</b></td>
		<td>El avión tendrá únicamente tres tipos de velocidades constantes que se podrán modificar con las teclas 1(lento), 2(normal) y 3(rápido).</td>
		<td>1 2 3</td>
	</tr> 
</table>

### **3.2 - Cámara**
La vista del juego será en tercera persona con respecto al avión, girando y moviéndose para mantener al jugador en el centro de la pantalla y mirando hacia delante en todo momento. 

<figure>
<p align="center"><img src="./imagenesGDD/vistaCamara.png" width=50% height=50%></p>
<figcaption><p align="center"><i><b>Imagen 1</b> - Ejemplo de vista en tercera persona de nuestro juego</i></p></figcaption>
</figure>

### **3.3 - Mecánicas de gameplay**
<table>
	<tr>
		<th>Mecánica</th>
		<th>Imagen</th>
		<th>Funcionamiento</th>
	</tr>
	<tr>
		<td>Brújula</td>
		<td></td>
		<td>Elemento que será útil para misiones que describan la ubicación del país destino como “al norte/sur/este/oeste de …”.</td>
	</tr>
	<tr>
		<td>Minimapa</td>
		<td></td>
		<td>Pequeña pantalla que muestra una versión más ampliada del mundo para ayudar al jugador a ubicarse por el mapa.</td>
	</tr>
	<tr>
		<td>Cliente</td>
		<td></td>
		<td>Durante la partida, el cliente mencionará curiosidades geográficas sobre el país destino. Además, transcurrido un tiempo específico, para ayudar al jugador y así evitar frustrar, el cliente le proporcionará una pista.El número total de pistas será 3, en caso de necesitarlas.</td>
	</tr>
	<tr>
		<td>Aeropuerto</td>
		<td></td>
		<td>Área donde podrás depositar a los clientes una vez hayas localizado el país correcto. Sólo podrás hacer ésto si pones el avión a velocidad lenta o “de aterrizaje”.</td>
	</tr>
	<tr>
		<td>Jefe</td>
		<td></td>
		<td>Personaje que te guiará en los niveles de aprendizaje y, pasado un tiempo suficientemente largo a determinar, te ofrecerá ayuda en los niveles normales / te avisará de imprevistos meteorológicos.</td>
	</tr>
</table>

## **4 - Diseño de nivel**
### **4.1 - Organización de niveles por continentes**
Los niveles del juego estarán organizados por continentes (Europa, Asia, África, América, Oceanía), y cada continente tendrá -n niveles (ej: 3). Antes de empezar las misiones de un nuevo continente, el jugador tendrá que jugar un nivel introductorio.
### **4.2 - Descripción del nivel introductorio**
En los niveles introductorios, el jefe te irá guiando por los “principales” países de ese continente, de los cuales ganarás tarjetas de información para consultar posteriormente (el jugador sigue conduciendo el avión, pero con marcadores en los países a los que tiene que ir).

Las tarjetas* que ganes en los niveles introductorios incluirán recuerdo, pero la foto mostrará a tu jefe en lugar de un cliente.
### **4.3 - Descripción de niveles posteriores (o imprevistos)**
En los niveles normales, el jugador recibirá una misión de su cliente, pidiéndole que le lleve a algún país específico. A lo largo del nivel, dependiendo de la complejidad puede tener varios clientes que le pidan ir a varios países. Si tarda mucho, o falla en encontrar el país, el cliente le irá dando pistas para facilitar encontrarlo. 
Además, en niveles algo más avanzados, podrán aparecer tormentas o imprevistos meteorológicos por el mapa que el jugador tendrá que esquivar.
En cada nivel el jugador podrá ganar hasta tres estrellas, aunque solo necesitará una para desbloquear el siguiente nivel y ganar una(s) tarjeta(s). En caso de ganar las 3, conseguirá un recuerdo del cliente para adornar su tarjeta de info.

## **5 - Interfaz**
### **5.1 - Mockup del HUD in-game**
#### **5.1.1 - Explicación de los elementos del HUD in-game y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Recuadro de misión</td>
		<td>-Aquí va una imagen del recuadro de misiones una vez acabado el juego-</td>
		<td>En la parte superior de la pantalla aparecerá un recuadro rectangular que contiene el objetivo de nuestra misión actual. Por ejemplo, si nuestro cliente quiere visitar un país al sur de Dinamarca, en la parte superior de la pantalla nos aparecerá un texto del estilo <i>Lleva al cliente a un país al sur de Dinamarca</i>.</td>
	</tr>
	<tr>
		<td>Pistas</td>
		<td>-Aquí va una imagen de las pistas una vez acabado el juego-</td>
		<td>Justo debajo de la imagen de nuestro cliente, aparecerán las sucesivas pistas que este te va dando si no consigues encontrar el país que este te pide. Las pistas son una lista vertical de tres bocadillos con un pequeño texto a modo de pista. Por ejemplo, siguiendo con el ejemplo anterior, podemos tener de pistas <i>Un monumento importante es la Puerta de Brandemburgo</i>, <i>Es la cuna de la industria automotriz europea</i> y <i>Su capital es Berlín</i>.</td>
	</tr>
	<tr>
		<td>Botón de menú de pausa</td>
		<td>-Aquí va una imagen del botón de menú de pausa una vez acabado el juego</td>
		<td>En la esquina inferior izquierda encontramos el botón que nos lleva al menú de pausa.</td>
	</tr>
</table>

### **5.2 - Mockup de la interfaz del menú inicial**
#### **5.2.1 - Explicación de los elementos de la interfaz del menú inicial y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Botón de "Jugar"</td>
		<td>-Aquí va una imagen del botón de jugar-</td>
		<td>Al pulsar este botón vamos al menú de los niveles, que va actuar como nuestro menú principal.</td>
	</tr>
	<tr>
		<td>Botón de "Salir"</td>
		<td>-Aquí va una imagen del botón de salir-</td>
		<td>Al pulsar este botón salimos del juego.</td>
	</tr>
</table>

### **5.3 - Mockup de la interfaz del menú de niveles/menú principal**
#### **5.3.1 - Explicación de los elementos de la interfaz del menú de niveles y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Lista de niveles</td>
		<td>-Aquí va una imagen con la lista de niveles-</td>
		<td>En la parte izquierda del menú encontramos una lista con todos los niveles jugables en nuestro juego. Los niveles están separados por continentes, y cada uno de los botones del nivel tiene el número de nivel y el número de estrellas conseguidas, inicialmente, 3 estrellas en color gris para luego rellenarse con estrellas doradas.</td>
	</tr>
	<tr>
		<td>Botón de ajustes</td>
		<td>-Aquí va una imagen del botón de jugar-</td>
		<td>En la esquina inferior derecha tenemos el botón con la rueda de ajustes, que al pulsar, nos lleva al menú de ajustes.</td>
	</tr>
	<tr>
		<td>Botón de tarjetas obtenidas</td>
		<td>-Aquí va una imagen del botón de jugar-</td>
		<td>En la esquina superior derecha nos encontramos con un botón, en forma de globo terráqueo, que contiene el submenú de las tarjetas obtenidas. En este menú tendremos una lista con todas las tarjetas de todos los países que hemos visitado a lo largo de los niveles que hemos jugado. Las tarjetas se explicarán mejor en el apartado <i><a href="#541---explicación-de-los-elementos-de-la-interfaz-del-menú-de-información-y-su-funcionamiento">5.4.1 - Explicación de los elementos de la interfaz del menú de información y su funcionamiento.</a></i></td>
	</tr>
	<tr>
		<td>Botón de volver atrás</td>
		<td>-Aquí va una imagen del botón de jugar-</td>
		<td>En la esquina inferior izquierda tenemos el botón que nos permite volver atrás al menú inicial, donde podremos salir del juego.</td>
	</tr>
</table>

### **5.4 - Mockup de la interfaz del menú de información**
#### **5.4.1 - Explicación de los elementos de la interfaz del menú de información y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Tarjetas de información</td>
		<td></td>
		<td>El menú entero está ocupado por una lista de tarjetas en las que encontraremos el nombre del país, su bandera, una foto de un lugar de interés del país e información referente a este, como por ejemplo capital, habitantes, comida típica, dato histórico curioso, etc... Las tarjetas se van desbloqueando conforme vayamos visitando países distintos durante el juego.</td>
	</tr>
</table>

### **5.5 - Mockup de la interfaz del menú de pausa**
#### **5.5.1 - Explicación de los elementos de la interfaz del menú de pausa y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Botón de volver al juego</td>
		<td></td>
		<td>Este botón nos permite volver al juego tal y donde lo dejamos.</td>
	</tr>
	<tr>
		<td>Botón de ajustes</td>
		<td></td>
		<td>Este botón nos permite ir al menú de ajustes.</td>
	</tr>
	<tr>
		<td>Botón de información</td>
		<td></td>
		<td>Este botón nos permite ir al menú de información para poder consultar los países ya visitados en caso de que se nos olviden en mitad de la partida.</td>
	</tr>
	<tr>
		<td>Botón de salir de la partida</td>
		<td></td>
		<td>Este botón nos permite volver al menú principal y abandonar el nivel en el que estamos actualmente.</td>
	</tr>
</table>

### **5.6 - Mockup de la interfaz del menú de ajustes**
#### **5.6.1 - Explicación de los elementos de la interfaz del menú de ajustes y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Botón de ajustes gráficos</td>
		<td></td>
		<td>Este botón nos llevará al menú de ajustes gráficos, en el que encontraremos ajustes para el brillo de la pantalla, resolución, pantalla completa, etc... -aún por ver lo que se va a meter-</td>
	</tr>
	<tr>
		<td>Botón de ajustes de sonido</td>
		<td></td>
		<td>Este botón nos llevará al menú de ajustes de sonido, en el que encontraremos ajustes para el volumen general, volumen de elementos de la interfaz, etc...</td>
	</tr>
	<tr>
		<td>Botón de controles</td>
		<td></td>
		<td>Este botón nos llevará al menú de controles, en el que podremos consultar los controles a usar con los diferentes elementos del juego.</td>
	</tr>
	<tr>
		<td>Botón de volver atrás</td>
		<td></td>
		<td>Este botón nos llevará al menú inmediatamente anterior, desde el cual hayamos accedido al menú de ajustes.</td>
	</tr>
</table>

### **5.7 - Mockup de la interfaz del menú de controles**
#### **5.7.1 - Explicación de los elementos de la interfaz del menú de controles y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Lista de controles</td>
		<td></td>
		<td>En pleno centro del menú encontraremos una lista con los controles que hemos definido para los diversos elementos del juego, por ejemplo, manejo del avión, interactuar con los clientes, aterrizar, cambiar velocidad del avión, etc...</td>
	</tr>
</table>


## **6 - Estética**
La estética del juego se basa en un estilo _cartoon_, suave, sencillo y colorido, pero sobre todo atractivo para nuestro público objetivo ideal. Una estética más realista y decorada puede llevar a los jugadores a la distracción, algo poco conveniente cuando se trata de un juego principalmente educativo; por ello, hemos decidido una estética más sobria y sencilla, la cual evite cualquier tipo de distracción y permita al jugador centrarse en el aprendizaje.

Este estilo se podrá ver en el diseño de las interfaces, las cuales están pensadas para ser sencillas y fáciles de usar; el diseño de los clientes, los cuales tendrán pocos detalles y serán muy sencillos; y, principalmente, el mapa terrestre, en el cual los países no tendrán ningún tipo de información acerca de los accidentes geográficos (es decir, montañas, ríos, valles, zonas nevadas, etc... no serán visibles en el mapa), ya que será un mapa plano en el que ¿¿(cada país tiene un color distinto a los países que lo rodean)??

## **7 - Menús y flujo de juego**

## **8 - Historia y personaje principal**

## **9 - Recursos**

## **10 - Referencias**
