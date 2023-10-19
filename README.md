# **GeoGuide - Game Design Document**
- [**GeoGuide - Game Design Document**](#geoguide---game-design-document)
	- [**1 - Ficha técnica**](#1---ficha-técnica)
	- [**2 - Descripción**](#2---descripción)
	- [**3 - Jugabilidad**](#3---jugabilidad)
		- [**3.1 - Mecánicas del jugador**](#31---mecánicas-del-jugador)
		- [**3.2 - Mapa**](#32---mapa)
		- [**3.3 - Mecánicas de escenario**](#33---mecánicas-de-escenario)
		- [**3.4 - Cámara**](#34---cámara)
	- [**4 - Diseño de nivel**](#4---diseño-de-nivel)
	- [**5 - HUD**](#5---hud)
	- [**6 - Visual**](#6---visual)
	- [**7 - Menús y flujo de juego**](#7---menús-y-flujo-de-juego)
	- [**8 - Contenido**](#8---contenido)
		- [**Personajes**](#personajes)
	- [**9 - Recursos**](#9---recursos)
	- [**10 - Arquitectura**](#10---arquitectura)
	- [**11 - Referencias**](#11---referencias)

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
		<td><b>Responder al cliente</b></td>
		<td>Durante la partida, el cliente podrá preguntar o hablar sobre curiosidades geográficas. En caso de ser una pregunta, el usuario podrá clickar una de las respuestas dentro de un tiempo limitado. Estas conversaciones con el cliente son opcionales pero, de responderlas correctamente, ganará tiempo extra.</td>
		<td>Click</td>
	</tr>
	<tr>
		<td><b>Aterrizar el avión</b></td>
		<td>En cada región del mundo, cuando el avión pase por encima aparecerá en la parte superior central de la pantalla el texto "Aterrizar", indicando que
		mientras este el texto este presente, si el jugador presiona la tecla ESPACIO, este podrá aterrizar. El jugador deberá atterizar en la región pedida por el 
		cliente ppara conseguir el mayor número de estrellas, las cuales se van reduci</td>
		<td>Barra espaceadora</td>
	</tr>
	<tr>
		<td><b>Consultar el mapa</b></td>
		<td></td>
		<td>Click</td>
	</tr>
	<tr>
		<td><b>Cambio de velocidad</b></td>
		<td></td>
		<td>Shift</td>
	</tr>
</table>

### **3.2 - Mapa**
### **3.3 - Mecánicas de escenario**
### **3.4 - Cámara**

## **4 - Diseño de nivel**

## **5 - HUD**
### 5.1 - Mockup del HUD in-game
#### 5.1.1 - Explicación de los elementos del HUD in-game y su funcionamiento
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

### 5.2 -  Mockup de la interfaz del menú inicial
#### 5.2.1 - Explicación de los elementos de la interfaz del menú inicial y su funcionamiento
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

### 5.3 - Mockup de la interfaz del menú de niveles/menú principal
#### 5.3.1 - Explicación de los elementos de la interfaz del menú de niveles y su funcionamiento
<table>
	<tr>
		<th><b>Elemento</b></th>
		<th><b>Imagen</b></th>
		<th><b>Explicación</b></th>
	</tr>
	<tr>
		<td>Lista de niveles</td>
		<td>-Aquí va una imagen con la lista de niveles-</td>
		<td>En la parte izquierda del menú de niveles encontramos una lista con todos los niveles jugables en nuestro juego. Los niveles están separados por continentes</td>
	</tr>
	<tr>
		<td>Botón de "Salir"</td>
		<td>-Aquí va una imagen del botón de jugar-</td>
		<td>Al pulsar este botón salimos del juego.</td>
	</tr>
</table>

### 5.4 - Mockup de la interfaz del menú de información
#### 5.4.1 - Explicación de los elementos de la interfaz del menú de información y su funcionamiento
### 5.5 - Mockup de la interfaz del menú de pausa
#### 5.5.1 - Explicación de los elementos de la interfaz del menú de pausa y su funcionamiento
### 5.6 - Mockup de la interfaz del menú de ajustes
#### 5.6.1 - Explicación de los elementos de la interfaz del menú de ajustes y su funcionamiento
### 5.7 - Mockup de la interfaz del menú de controles
#### 5.7.1 - Explicación de los elementos de la interfaz del menú de controles y su funcionamiento



## **6 - Visual**

## **7 - Menús y flujo de juego**

## **8 - Contenido**
### **Personajes**

## **9 - Recursos**

## **10 - Arquitectura**

## **11 - Referencias**
