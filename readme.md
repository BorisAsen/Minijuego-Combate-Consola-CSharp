# Minijuego de Combate en Consola con C#

Proyecto de consola simple con el fin de repasar el manejo de listas y la manipulacion de archivos (apertura y escritura).

## Descripción del sistema y el juego

El sistema consiste en un juego de combate basado en objetos de la clase "Personaje", los cuales tendran como atributos: Id, Clase, Ataque, Defensa y Probabilidad de golpe critico. La batalla sera por turnos (3 para cada personaje) y el que empieza se decidira al azar. El ataque de un personaje hacia otro se calculara como el ataque base multiplicado por un numero aleatorio entre 1 y el valor de su probabilidad de golpe critico que actuara como multiplicador, el resultado de esto se restara a la vida del oponente. El ganador sera aquel que termine con mas vida luego del combate, si alguno llega a quedar con cero vida antes del final se considerara perdedor. Los ataques tendran cierto grado de efectividad segun la clase de personajes que se enfrenten: el ataque de un mago es un 5% mas efectivo contra un tanque pero a su vez un ataque de tanque es 10% mas dañino contra el, un luchador le hace un 6% mas de daño a los tanques pero tambien un 8% menos a los magos.
Al ejecutar el proyecto se observara por pantalla un menu con las opciones para:
- Iniciar un combate
- Agregar un personaje
- Modificar personajes
- Buscar personajes por cierto atributo
- Ver el historial de peleas.

En base a estas posibilidades se implementara principalmente la lectura de un archivo csv, creacion de objetos o listas de objetos, operaciones de listas, escritura de archivos csv y txt ya sea overwrite o append, entre otras cosas.

## Funcionalidades principales

- Iniciar un combate: Se listaran los personajes guardados y se podra elegir uno para luchar contra un personaje aleatorio propuesto por el juego.
- Agregar un personaje: Crear un personaje con las caracteristicas que se quiera y guardarlo en el archivo csv de personajes.
- Modificar personajes: Cambiar los atributos de uno o varios personajes.
- Buscar un personaje: Encontrar el personaje con mas vida, con mas ataque y contar la cantidad de cada clase (Mago, Luchador o Tanque).
- Mostrar el historial de peleas: Se podran ver el resultado de los combates que se realizaron.

