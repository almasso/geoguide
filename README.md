# **GeoGuide - Game Design Document**
<p align="center"><img src="./imagenesGDD/geoguideTitulo.png"></p>

- [**Índice**](#geoguide---game-design-document)
	- [**1 - Ficha técnica**](#1---ficha-técnica)
	- [**2 - Descripción**](#2---descripción)
	- [**3 - Propósito educativo y contexto de uso**](#3---propósito-educativo-y-contexto-de-uso)
	- [**4 - Interés y aprendizaje del jugador**](#4---interés-y-aprendizaje-del-jugador)
	- [**5 - Jugabilidad**](#5---jugabilidad)
		- [**5.1 - Mecánicas del jugador**](#51---mecánicas-del-jugador)
		- [**5.2 - Cámara**](#52---cámara)
		- [**5.3 - Mecánicas de gameplay**](#53---mecánicas-de-gameplay)
	- [**6 - Historia y personaje principal**](#6---historia-y-personaje-principal)
	- [**7 - Diseño de nivel**](#7---diseño-de-nivel)
		- [**7.1 - Organización de niveles por continentes**](#71---organización-de-niveles-por-continentes)
		- [**7.2 - Descripción del nivel introductorio**](#72---descripción-del-nivel-introductorio)
		- [**7.3 - Descripción de niveles posteriores**](#73---descripción-de-niveles-posteriores)
			- [**7.3.1 - Objetivo**](#731---objetivo)
			- [**7.3.2 - Reparto de estrellas**](#732---reparto-de-estrellas)
			- [**7.3.3 - Pistas**](#733---pistas)
			- [**7.3.4 - Imprevistos**](#734---imprevistos)
		- [**7.4 - Tarjetas**](#74---tarjetas)
	- [**8 - Interfaz**](#8---interfaz)
		- [**8.1 - Mockup del HUD in-game**](#81---mockup-del-hud-in-game)
			- [**8.1.1 - Explicación de los elementos del HUD in-game y su funcionamiento**](#811---explicación-de-los-elementos-del-hud-in-game-y-su-funcionamiento)
		- [**8.2 - Mockup de la interfaz del menú inicial**](#82---mockup-de-la-interfaz-del-menú-inicial)
			- [**8.2.1 - Explicación de los elementos de la interfaz del menú inicial y su funcionamiento**](#821---explicación-de-los-elementos-de-la-interfaz-del-menú-inicial-y-su-funcionamiento)
		- [**8.3 - Mockup de la interfaz del menú de niveles/menú principal**](#83---mockup-de-la-interfaz-del-menú-de-nivelesmenú-principal)
			- [**8.3.1 - Explicación de los elementos de la interfaz del menú de niveles y su funcionamiento**](#831---explicación-de-los-elementos-de-la-interfaz-del-menú-de-niveles-y-su-funcionamiento)
		- [**8.4 - Mockup de la interfaz del menú de información**](#84---mockup-de-la-interfaz-del-menú-de-información)
			- [**8.4.1 - Explicación de los elementos de la interfaz del menú de información y su funcionamiento**](#841---explicación-de-los-elementos-de-la-interfaz-del-menú-de-información-y-su-funcionamiento)
		- [**8.5 - Mockup de la interfaz del menú de pausa**](#85---mockup-de-la-interfaz-del-menú-de-pausa)
			- [**8.5.1 - Explicación de los elementos de la interfaz del menú de pausa y su funcionamiento**](#851---explicación-de-los-elementos-de-la-interfaz-del-menú-de-pausa-y-su-funcionamiento)
		- [**8.6 - Mockup de la interfaz del menú de controles**](#86---mockup-de-la-interfaz-del-menú-de-controles)
			- [**8.6.1 - Explicación de los elementos de la interfaz del menú de controles y su funcionamiento**](#861---explicación-de-los-elementos-de-la-interfaz-del-menú-de-controles-y-su-funcionamiento)
	- [**9 - Estética**](#9---estética)
	- [**10 - Menús y flujo de juego**](#10---menús-y-flujo-de-juego)
	- [**11 - Recursos**](#11---recursos)
	- [**12 - Referencias**](#12---referencias)
	- [**13 - Menciones**](#13---menciones)

## **1 - Ficha técnica**
- **Título**: *GeoGuide*
- **Género**: Juego serio de simulación
- **Público objetivo**: Estudiantes de 8 a 15 años interesados en el aprendizaje de Geografía, sin necesidad de una base previa, de forma dinámica y entretenida.
- **Rating**: PEGI 7
- **Plataforma**: PC (Windows), Resolución remomendada: 16:9 (1920 x 080).
- **Modos de juego**:
	- Un jugador.

## **2 - Descripción**
Juego casual, de simulación, enfocado en el aprendizaje y descubrimiento geográfico, en el que el jugador pilotará un avión transportando clientes por el mundo al destino que le pidan y aprenderá todo tipo de datos interesantes sobre los países visitados.

## **3 - Propósito educativo y contexto de uso**
GeoGuide tiene como objetivo enseñar geografía mundial desde cero a estudiantes jóvenes, sin necesidad de base previa. Esto se realiza mediante técnicas de enseñanza como el refuerzo positivo y la asociación de conceptos en lugar de las técnicas habituales de memorización y prueba y error.

Gracias a una breve introducción guiada de algunos países y a las cartas de información, llenas de datos interesantes sobre los lugares visitados, el usuario podrá llevar a sus clientes a cualquier parte del mundo, relacionando la información dada previamente, ampliando su conocimiento. Toda la información dada se guarda en las tarjetas informativas no sólo para ayudar al jugador a situarse, sino también para crear recuerdos y asociarlos a lugares.

En cuanto al contexto de uso, hemos tenido en cuenta los contenidos de las asignaturas de Geografía (y similares) que se imparten en los colegios e institutos (establecida por la actual ley LOMLOE) a alumnos dentro de nuestro rango de edad objetivo: en el colegio, principalmente se suele profundizar en la geografía física y política del territorio nacional (entre 1º de Primaria y 4º de Primaria), empezándose a ver las geografías política y física del territorio europeo a partir de 5º de Primaria; mientras que en el Instituto, entre los cursos de 1º de la ESO hasta 3º de la ESO se suelen ver, de manera sucesiva, tanto los mapas políticos de Europa, como los de África, América y Asia (no se suele hacer mucho hincapié en la geografía de Oceanía). 

Es por eso que GeoGuide puede ser usado en clase como ejercicio dinámico y divertido para que los alumnos aprendan (por ejemplo, el profesor podría pedirle a sus alumnos que intenten resolver los niveles del continente que estén estudiando); pero también puede ser un apoyo extra para que los alumnos practiquen de manera autónoma en casa, a modo de refuerzo de la lección estudiada anteriormente o a modo de repaso para un examen.

## **4 - Interés y aprendizaje del jugador**
En el diseño del juego, hemos tenido en cuenta elementos que nos ayudan a mantener el interés de nuestros jugadores y a asegurarnos de que están aprendiendo, por ejemplo:
la narrativa, que presenta una historia de progreso, con una meta final definida, apoyada por un sistema de niveles por estrellas, que les presentan a los jugadores el reto de conseguirlos todos con la mejor puntuación posible, reforzados por recompensas extra si consiguen las 3 (puntuación máxima). 
Además, dentro de los propios niveles, nos aseguramos de que el jugador no se frustre en exceso y mantenga la atención mediante un reloj interno que comprueba si el jugador lleva demasiado tiempo sin acertar desde que comenzó el nivel y le aporta pistas correspondientemente. Pasados los tres intentos fallidos o demasiado tiempo, se le "chivará" al jugador dónde estaba el país destino. El nivel no contará como completado pero evitará que el jugador se frustre en caso de atascarse, y siempre será libre de volver a repetirlo desde el inicio.

## **5 - Jugabilidad**
### **5.1 - Mecánicas del jugador**
<table>
	<tr>
		<th>Acciones</th>
		<th>Descripción</th>
		<th>Input</th>
	</tr>
	<tr>
		<td><b>Pilotar el avión</b></td>
		<td>En cada nivel el avión se moverá constantemente hacia delante con una velocidad constante inicial. El usuario podrá girarlo hacia la derecha e izquierda con A y D respectivamente; y subir y bajar con W y S, respectivamente.</td>
		<td>W A S D</td>
	</tr>
	<tr>
		<td><b>Aterrizar avión</b></td>
		<td>Cada país del mundo tendrá un <u><a href="#53---mecánicas-de-gameplay">aeropuerto</a></u>. Una vez se ha llegado al aeropuerto del país destino, el jugador podrá aterrizar pulsando el espacio. Una vez aterrizado se decidirá las <u><a href="#73---descripción-de-niveles-posteriores">estrellas</a></u> conseguidas.</td>
		<td>Barra espaceadora</td>
	</tr>
	<tr>
		<td><b>Cambio de velocidad</b></td>
		<td>El avión tendrá únicamente tres tipos de velocidades constantes que se podrán modificar con las teclas 1(lento), 2(normal) y 3(rápido).</td>
		<td>1 2 3</td>
	</tr> 
</table>

### **5.2 - Cámara**
La vista del juego será en tercera persona con respecto al avión, girando y moviéndose para mantener al jugador en el centro de la pantalla y mirando hacia delante en todo momento. 

<figure>
<p align="center"><img src="./imagenesGDD/hud_partida.png" width=50% height=50%></p>
<figcaption><p align="center"><i><b>Imagen 1</b> - Ejemplo de vista en tercera persona de nuestro juego</i></p></figcaption>
</figure>

### **5.3 - Mecánicas de gameplay**
<table>
	<tr>
		<th>Mecánica</th>
		<th>Imagen</th>
		<th>Funcionamiento</th>
	</tr>
	<tr>
		<td>Brújula</td>
		<td><img src="./imagenesGDD/brujula.png" width=50% height=50%></td>
		<td>Elemento que será útil para misiones que describan la ubicación del país destino como “al norte/sur/este/oeste de …”. La parte central es estática y simboliza la dirección en la que se mueve el avión, mientras que la exterior rota conforme su dirección al mundo.</td>
	</tr>
	<tr>
		<td>Velocímetro</td>
		<td><img src="./imagenesGDD/velocimetro.jpeg" width=50% height=50%></td>
		<td>Debajo de la brújula aparecerá un pequeño indicador que muestra la velocidad a la que el jugador va: 1 (lento, aterrizar); 2 (medio); 3 (rápido). En color verde se mostrará la velocidad actual. Si en algún momento tenemos alguno de los motores nos fallase, tanto las velocidades 2 como 3 aparecerán en rojo, indicando que están bloqueadas y que por tanto solo se puede ir en la velocidad más baja.</td>
	</tr>
	<tr>
		<td>Minimapa</td>
		<td><img src="./imagenesGDD/minimapa.png" width=50% height=50%></td>
		<td>Pequeño rectángulo, ubicado en la esquina inferior derecha del HUD, que muestra la posición del jugador más alejada del suelo para ayudar al jugador a ubicarse por el mundo, en vista bidimensional, al estilo de un mapa. Para indicar de forma precisa al jugador, este aparecerá como un avión rojo. El minimapa solo rotará cuando sea necesario cambiar la vista al norte, esto es, si atravesamos alguno de los polos y la vista se invierte.</td>
	</tr>
	<tr>
		<td>Cliente</td>
		<td>
			<figure>
				<p align=left><img src="./imagenesGDD/cliente.png" width=50% height=50%></p>
				<figcaption><p align="left"><i>Depende del cliente</i></p>
			</figure>
		</td>
		<td>Transcurrido un tiempo específico, establecido en un minuto, o si el jugador falla de país objetivo, el cliente le proporcionará una pista al jugador para ayudar y así evitar frustrar. El número total de pistas será de 3, en caso de necesitarlas. Solo aparecen en los niveles normales y nunca en los introductorios. En total hay 22 modelos distintos de cliente.</td>
	</tr>
	<tr>
		<td>Aeropuerto</td>
		<td><img src="./imagenesGDD/aeropuerto.png" width=100% height=100%></td>
		<td>Marcador flotante, que establece el lugar en el que el jugador debe aterrizar en cada país. Sólo podrás hacer ésto si pones el avión a velocidad lenta o “de aterrizaje”. Una vez hayas aterrizado, si el país fue el correcto se pasará al siguiente cliente en caso de haberlo, o terminará el nivel. Si se ha fallado, se notificará, se restará un intento y el jugador podrá continuar. Los aeropuertos, tendrán todos color rojo, excepto, en los niveles introductorios o una vez que tu jefe te guíe al país destino, en cuyo caso, el aeropuerto destino se iluminará de color verde, resaltando entre los demás para facilitar la vista del objetivo.</td>
	</tr>
	<tr>
		<td>Jefe</td>
		<td><img src="./imagenesGDD/dad.png" width=50% height=50%></td>
		<td>Personaje que te guiará en los niveles de aprendizaje/introductorios. Tendrá el mismo funcionamiento que los clientes en los niveles normales, pero sin proporcionar pistas. Si pasado un tiempo suficientemente largo no has adivinado el país o fallas una vez desbloqueadas las tres pistas, te guiará al país destino para que evitar que el jugador se sienta bloqueado, ni se atasque en algún nivel.En los demás niveles será sustituido por un walkie-talkie, ya que los clientes ocuparán su lugar en el HUD.</td>
	</tr>
	<tr>
		<td>Walkie-talkie</td>
		<td><img src="./imagenesGDD/walkie.png" width=50% height=50%></td>
		<td>En los niveles normales, y siempre que haya un imprevisto, se haya fallado de país, etc..., aparecerá desde la parte inferior de la pantalla un walkie-talkie con un bocadillo explicando la situación, con frases como <i>¡Vaya, parece que hay niebla en Polonia! ¡Evita pasar por ese país a toda costa!</i> o <i>¡Vaya! Ese país no era tu objetivo. ¡Sigue intentándolo!</i>, etc...
	</tr>
</table>

**Todo el arte se hará a mano o se usarán assets previamente creados *free to use* o a los que tengamos permisos. Cualquier asset externo será incluido en la parte de [recursos](#11---recursos)**


## **6 - Historia y personaje principal**
Como jugador encarnarás al hijo de un director (en otros apartados aparecerá como “Jefe”) de una agencia de viajes aérea, que ha decidido jubilarse y dejar el negocio familiar en tus manos. Has estudiado muy duro, pero apenas tienes práctica, por lo que entrarás a la flota como piloto júnior. Es por eso que tu padre ha diseñado un plan para que llegues a ser un piloto sénior en el menor tiempo posible antes de delegar la empresa en ti. Este plan tiene como objetivo dominar los mandos del avión y aprender qué rutas ofrece la empresa a los distintos países.

Este plan en la historia se relaciona de manera directa con el gameplay del juego: que el protagonista aprenda a dominar los mandos del avión se relaciona con que el usuario aprenda los controles físicos (teclado) del avión; mientras que las rutas que se ofrecen son el contenido educativo geográfico que se plantea enseñar en nuestro juego.

## **7 - Diseño de nivel**
La historia comienza en Europa, el primer nivel (introductorio), donde el jefe le dará la enhorabuena al jugador (su hijo) por estar preparado al fin para aceptar el puesto de piloto junior y heredar así su agencia turística de viajes. El jefe le explicará al usuario cómo pilotar este tipo de avión, y le asegurará que él se encargará de enseñarle lo básico.

A continuación, el jefe enseñará al jugador los controles básicos para manejar el avión y le mostrará los primeros países, dándole unas [tarjetas de información](#74---tarjetas) que contendrán datos importantes e interesantes de cada país. A partir de ahí comenzará el juego, donde el jugador viajará por todo el mundo e irá coleccionando tarjetas informativas.
### **7.1 - Organización de niveles por continentes**
Los niveles del juego estarán organizados por continentes (Europa, Asia, África, América, Oceanía), cada uno conteniendo un número de niveles definido (por ejemplo, 3). Antes de empezar las misiones normales de un nuevo continente, el jugador tendrá que jugar un nivel introductorio. Para desbloquear los siguientes niveles, tanto dentro de un mismo continente, como entre continentes, será necesario tener un mínimo de **una** estrella en el nivel previamente desbloqueado.
### **7.2 - Descripción del nivel introductorio**
En los niveles introductorios, el jefe te irá guiando por los “principales” países de ese continente, de los cuales ganarás tarjetas de información para consultar posteriormente. Estas tarjetas también incluirán recuerdos.
### **7.3 - Descripción de niveles posteriores**
#### **7.3.1 - Objetivo**
El **objetivo** de cada nivel es llevar al cliente o clientes a sus destinos deseados.

En los niveles **normales**, el jugador recibirá una misión de su cliente, pidiéndole que le lleve a algún país específico. El cliente puede pedirle directamente al jugador su destino indicando el nombre del país al que quiere viajar, o bien algún dato concreto del país que pueda identificarlo fácilmente. Estos datos **siempre** provendrán de información que el propio juego le proporciona al usuario con las tarjetas de información.

En los niveles difíciles, el jugador tendrá varias misiones consecutivas en un mismo nivel y afrontará algunos *imprevistos*. La dificultad incrementará con cada nivel dentro de un mismo continente.
#### **7.3.2 - Reparto de estrellas**
En cada nivel el jugador podrá ganar hasta **tres estrellas**. El reparto de estas depende de los intentos acumulados, independientemente del tiempo transcurrido. Por tanto, si el jugador acierta el país a la primera ganará 3 estrellas, si lo adivina a la segunda 2 estrellas y a la tercera 1. Los fallos se acumulan si el nivel tiene varios países a los que visitar. Si se vuelve a fallar tras el tercer intento, o bien transcurrido ya mucho tiempo desde el inicio de la partida (4 minutos), el jefe guiará al jugador al país destino y el nivel se contará como **no completado**, teniendo que repetirlo para poder seguir adelante.

El jugador solo necesitará **1 estrella** para desbloquear el siguiente nivel y ganar una(s) tarjeta(s). En caso de ganar las **3 estrellas**, conseguirá un recuerdo para adornar su tarjeta de información.
#### **7.3.3 - Pistas**
Si el jugador tarda mucho en encontrar el país o falla, el cliente le irá dando pistas para facilitar encontrarlo. Estas pistas estarán repartidas durante el juego usando un cronómetro interno o por intentos fallidos. Por ejemplo: pasado 1 minuto, si el jugador aún no sabe dónde ir, se dará la primera para evitar que se frustre e intentar guiarlo. Pasado 1 minuto desde la primera pista o si se falla se proporcionará la siguiente y, tras otro minuto o si se vuelve a fallar, la última.

Ya que nuestro juego se basa en el aprendizaje desde cero, no queremos frustrar ni castigar al usuario por fallar. Nuestra intención es que el usuario identifique y relacione los países a los datos proporcionados por el jefe, los clientes y las tarjetas. Queremos evitar la filosofía de “prueba y error” y que estos lugares sean más que un punto en el mapa. Por eso mismo, se le proporcionarán 3 pistas y, tras ellas, si el jugador aún está perdido, se le guiará hacia el destino.
#### **7.3.4 - Imprevistos**
Durante los niveles **difíciles**, el jefe avisará por radio sobre posibles imprevistos meteorológicos (nieve, niebla o tormenta) por el mapa que el jugador tendrá que esquivar. 

Estos imprevistos no se podrán ver físicamente en el mapa, sin embargo, si el jugador pasa por el país afectado, esta le causará daños en el equipamiento del avión y perderá una de estas tres cosas:
- **Brújula**: La brújula empezará a girar erráticamente, por lo que impedirá usarla para poder ubicar los distintos países del mapa, dificultando algunas misiones que tengan puntos cardinales como pista.
- **Minimapa**: El minimapa se romperá y en su lugar aparecerá una niebla/estática, por lo que el jugador perderá la opción de extrapolar su posición y aumentará la posibilidad de sentirse perdido o desubicado.
- **Motores**: el avión perderá su velocidad turbo y solo podrá ir a velocidad normal o de aterrizaje.

Estos imprevistos durarán alrededor de unos 10 segundos, en los que el jugador verá limitados los usos de una de estas mecánicas, dificultando, en alguna ocasión, el poder ubicarse bien en el mapa, haciendo de esta mecánica un desafío añadido a la búsqueda del país correcto.

### **7.4 - Tarjetas**
Cada país que visitemos en alguno de los niveles nos proporcionará una tarjeta con información sobre éste, como por ejemplo su bandera, su capital, el idioma que se habla y algún dato interesante. Además, si en el nivel en el que se consigue esa tarjeta hemos conseguido las tres estrellas, o era un nivel introductorio, la tarjeta incluirá también una pequeña postal con el cliente al que llevamos a ese país (o con nuestro jefe en caso de los niveles introductorios), posando con algún monumento famoso de ese país.

Una vez conseguida cada tarjeta, esta estará disponible en el menú de información, al que podremos acceder tanto antes como durante los niveles de juego, y su información nos será útil tanto para encontrar otros países colindantes como para repasar lo aprendido.
Además, el hecho de que las postales sólo aparecen si consigues las 3 estrellas, motivará al jugador a intentar conseguirlas para completar el álbum y tener un memento de su esfuerzo y su aprendizaje.
<figure>
<p align="center"><img src="./imagenesGDD/Tarjeta Pais Bloqueada.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 2</b> - Ejemplo de tarjeta bloqueada</i></p></figcaption>
</figure>
<figure>
<p align="center"><img src="./imagenesGDD/tarjeta.png" width=50% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 3</b> - Implementación final de las tarjetas de información.</i></p></figcaption>
</figure>

## **8 - Interfaz**
### **8.1 - Mockup del HUD in-game**
<figure>
<p align="center"><img src="./imagenesGDD/hud_partida.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 4</b> - Imagen final del HUD in-game</i></p></figcaption>
</figure>

#### **8.1.1 - Explicación de los elementos del HUD in-game y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Recuadro de misión</td>
		<td>En la parte superior de la pantalla aparecerá un recuadro conteniendo el objetivo de la misión actual. Por ejemplo, se nos podría pedir <i>si podemos visitar un país muy poblado al sur de Dinamarca</i>.</td>
	</tr>
	<tr>
		<td>Pistas</td>
		<td>Justo debajo de la imagen de nuestro cliente, aparecerán las sucesivas pistas que este te va dando si no consigues encontrar el país que este te pide. Las pistas son una lista vertical de tres recuadros con un pequeño texto a modo de pista. Las flechas que aparecen permiten ocultar y mostrar en pantalla las pistas en caso de que no se quiera perder visibilidad. Por ejemplo, siguiendo con el ejemplo anterior, podemos tener de pistas <i>Un monumento importante es la Puerta de Brandeburgo</i>, <i>Es la cuna de la industria automotriz europea</i> y <i>Su capital es Berlín</i>.</td>
	</tr>
	<tr>
		<td>Botón de menú de pausa</td>
		<td>Se mantiene en pantalla en todo momento durante la misión. Situado en la parte inferior izquierda, tiene forma de engranaje.</td>
	</tr>
</table>

### **8.2 - Mockup de la interfaz del menú inicial**
<figure>
<p align="center"><img src="./imagenesGDD/menu_inicial.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 5</b> - Diseño final del menú inicial</i></p></figcaption>
</figure>

#### **8.2.1 - Explicación de los elementos de la interfaz del menú inicial y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Botón "Start"</td>
		<td>Al pulsar este botón vamos al menú de los niveles, que va actuar como nuestro menú principal.</td>
	</tr>
	<tr>
		<td>Botón "Quit"</td>
		<td>Al pulsar este botón salimos del juego.</td>
	</tr>
</table>

### **8.3 - Mockup de la interfaz del menú de niveles/menú principal**
<figure>
<p align="center"><img src="./imagenesGDD/menu_niveles.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 6</b> - Diseño final del menú principal</i></p></figcaption>
</figure>

#### **8.3.1 - Explicación de los elementos de la interfaz del menú de niveles y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Lista de niveles</td>
		<td>En la parte izquierda del menú encontramos una lista con todos los niveles jugables en nuestro juego. Los niveles están separados por continentes, y cada uno de los botones del nivel tiene el número de nivel y el número de estrellas conseguidas, inicialmente, 3 estrellas en color gris para luego rellenarse con estrellas doradas.</td>
	</tr>
	<tr>
		<td>Botón de ajustes</td>
		<td>En la esquina superior derecha tenemos el botón en forma de engranaje, que al pulsar, nos lleva al menú de ajustes.</td>
	</tr>
	<tr>
		<td>Botón de tarjetas obtenidas</td>
		<td>En la esquina superior derecha, debajo del botón de ajustes, nos encontramos con un botón, en forma de globo terráqueo, que contiene el submenú de las tarjetas obtenidas. En este menú tendremos una lista con todas las tarjetas de todos los países que hemos visitado a lo largo de los niveles que hemos jugado. Las tarjetas se explicarán mejor en el apartado <a href="#841---explicación-de-los-elementos-de-la-interfaz-del-menú-de-información-y-su-funcionamiento"><b>8.4.1 - Explicación de los elementos de la interfaz del menú de información y su funcionamiento</b></a></td>
	</tr>
	<tr>
		<td>Botón de volver atrás</td>
		<td>En la esquina inferior izquierda tenemos el botón que nos permite volver atrás al menú inicial, donde podremos salir del juego. Este botón tiene forma de avión, simulando las típicas flechas de los menús de interfaces.</td>
	</tr>
</table>

### **8.4 - Mockup de la interfaz del menú de información**
<figure>
<p align="center"><img src="./imagenesGDD/menu_tarjetas.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 7</b> - Diseño final del menú de información</i></p></figcaption>
</figure>

#### **8.4.1 - Explicación de los elementos de la interfaz del menú de información y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Tarjetas de información</td>
		<td>El menú entero está ocupado por una lista de las tarjetas de los países, explicadas anteriormente en <a href="#74---tarjetas"><i>el apartado 7.4</i></a>.</td>
	</tr>
	<tr>
		<td>Botón de volver atrás</td>
		<td>En la esquina superior izquierda tenemos el botón que nos permite volver atrás al menú inicial, explicado anteriormente.</td>
	</tr>
</table>

### **8.5 - Mockup de la interfaz del menú de pausa**
<figure>
<p align="center"><img src="./imagenesGDD/menu_pausa.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 8</b> - Diseño final del menú de pausa</i></p></figcaption>
</figure>

#### **8.5.1 - Explicación de los elementos de la interfaz del menú de pausa y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Botón "Settings"</td>
		<td>Este botón nos permite ir a los ajustes del juego.</td>
	</tr>
	<tr>
		<td>Botón "Info Cards"</td>
		<td>Este botón nos permite ir al menú de información para poder consultar los países ya visitados en caso de que se nos olviden en mitad de la partida.</td>
	</tr>
	<tr>
		<td>Botón "Levels"</td>
		<td>Este botón nos permite ir al menú de niveles/menú principal en caso de que querramos cambiar de nivel o salir del juego.</td>
	</tr>
	<tr>
		<td>Botón "Back"</td>
		<td>Este botón nos permite volver a la partida y retomarla tal y por donde estábamos.</td>
	</tr>
</table>

### **8.6 - Mockup de la interfaz del menú de controles**
<figure>
<p align="center"><img src="./imagenesGDD/menu_controles.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 9</b> - Mockup del menú de controles</i></p></figcaption>
</figure>

#### **8.6.1 - Explicación de los elementos de la interfaz del menú de controles y su funcionamiento**
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Lista de controles</td>
		<td>Se explicarán los controles utilizados durante el gameplay. </td>
	</tr>
</table>


## **9 - Estética**
La estética del juego se basa en una mezcla de estilo cartoon, suave, sencillo y colorido, pero sobre todo atractivo para nuestro público objetivo ideal y permite al jugador centrarse en el aprendizaje, que se podrá ver en el diseño de las interfaces, las cuales están pensadas para ser sencillas y fáciles de usar y en el diseño de los clientes, los cuales tendrán pocos detalles y serán muy sencillos; mientras que también tenemos un estilo realista y detallado, el cual podremos ver exclusivamente en el mapa terrestre, para que los jugadores puedan aprender también sobre la información física de los países.

## **10 - Menús y flujo de juego**
<figure>
<p align="center"><img src="./imagenesGDD/flujoJuego.png" width=100% height=100%></p>
<figcaption><p align="center"><i><b>Imagen 10</b> - Diagrama de flujo de juego de todos los menús e interfaces</i></p></figcaption>
</figure>

## **11 - Recursos**
- [Mapas para la demo](https://www.mapsofindia.com/world-map/outline.html)
- [Avatares 1 para clientes/jefe](https://www.freepik.com/free-vector/set-people-avatars-round-icons-with-faces-young-old-male-female-characters-diverse-men-women-with-different-hair-color-kids-teens-adult-isolated-line-art-flat-vector-portraits_25917849.htm)
- [Avatares 2 para clientes/jefe](https://www.freepik.com/free-vector/people-avatars-social-media-profile_25845390.htm)
- [Avión para la brújula](https://www.freepik.es/foto-gratis/avion-sobre-concepto-viaje-plano-fondo-rosa_38935972.htm#page=2&query=cartoon%20plane%20topdown&position=1&from_view=search&track=ais&uuid=cf770c24-d190-4e46-92d7-bbc06c71e781)
- [Walkie-talkie](https://www.freepik.es/vector-gratis/elemento-guardaespaldas-dibujado-mano_41538556.htm#query=cartoon%20walkie%20talkie&position=2&from_view=search&track=ais&uuid=4bfa1e30-bbec-4878-82b1-adbb56b2af9c)
- [Sonido de aterrizaje](https://freesound.org/people/estefypardo/sounds/707658/)
- [Click de la UI](https://freesound.org/people/florianreichelt/sounds/683099/
)
- [Interferencias Walkie-Talkie 1](https://freesound.org/people/crcavol/sounds/154644/)
- [Interferencias Walkie-Talkie 2](https://freesound.org/people/MiscPractice/sounds/676958/)
- [Sonido de estática para el minimapa](https://freesound.org/people/DiscoverSound/sounds/273147/)
- [Partida perdida](https://freesound.org/people/Rolly-SFX/sounds/626260/)
- [Victoria](https://freesound.org/people/Rolly-SFX/sounds/626259/)
- [Música de fondo 1](https://www.chosic.com/download-audio/28063/)
- [Música de fondo 2](https://pixabay.com/users/29811401-29811401/)
- [Música de fondo 3](https://pixabay.com/users/logigram-20199743/)
- [Sonido papel tarjetas de información 1](https://freesound.org/people/gynation/sounds/82377/)
- [Sonido papel tarjetas de información 2](https://freesound.org/people/SholeColtis/sounds/683427/)
- [Sonido de pistas](https://freesound.org/people/djlprojects/sounds/413629/)
- [Sonido de clientes](https://freesound.org/people/ValentinPetiteau/sounds/557373/)

## **12 - Referencias**
### **12.1 - Videojuegos**
- [*GeoGuessr* (2013)](https://www.geoguessr.com/es), videojuego en web diseñado por [**Anton Wallén**](https://twitter.com/antonwallen).
- [*Geotastic* (2021)](https://geotastic.net/home), videojuego similar a *GeoGuessr* creado por [*Edutastic Games*](https://www.edutastic.de).
- [*Geographical Adventures* (2022)](https://sebastian.itch.io/geographical-adventures), videojuego creado por [**Sebastian Lague**](https://www.youtube.com/@SebastianLague) en su serie de YouTube homónima.
- [*Microsoft Flight Simulator*](https://www.flightsimulator.com), serie de videojuegos de simulación aérea creada por Microsoft.

## **13 - Menciones**
Este juego es un proyecto académico del Grado de Desarrollo de Videojuegos para la asignatura de Juegos Serios, perteneciente al [Departamento de Software e Inteligencia Artificial de la Facultad de Informática](https://www.ucm.es/disia) de la [Universidad Complutense de Madrid](https://ucm.es/).

[VÍDEO DE LA ENTREGA FINAL - 8 MINUTOS](https://youtu.be/w-DX-6kCYtc)
