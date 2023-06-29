# Minijuego de Combate en Consola con C#

Proyecto de consola simple con el fin de repasar el manejo de listas y la manipulacion de archivos (apertura y escritura).

## Descripción del sistema y el modo de juego

El sistema consiste en un juego de combate basado en objetos de la clase "Personaje", los cuales tendran como atributos: Id, Clase, Ataque, Defensa y Probabilidad de golpe critico. La batalla sera por turnos (3 para cada personaje) y el que empieza se decidira al azar. El ataque de un personaje hacia otro se calculara como el ataque base multiplicado por un numero aleatorio entre 1 y el valor de su probabilidad de golpe critico que actuara como multiplicador, el resultado de esto se restara a la vida del oponente. El ganador sera aquel que termine con mas vida luego del combate, si alguno llega a quedar con cero vida antes del final se considerara perdedor. Los ataques tendran cierto grado de efectividad segun la clase de personajes que se enfrenten: el ataque de un mago es un 5% mas efectivo contra un tanque pero a su vez un ataque de tanque es 10% mas dañino contra el, un luchador le hace un 6% mas de daño a los tanques pero tambien un 8% menos a los magos.
Al ejecutar el proyecto se observara por pantalla un menu con las opciones para:
- Mostrar Personajes
- Iniciar un combate
- Agregar un personaje
- Modificar personajes
- Salir del Juego

En base a estas posibilidades se implementara principalmente la lectura de un archivo csv, creacion de objetos o listas de objetos, operaciones de listas, escritura de archivos csv y txt ya sea overwrite o append, entre otras cosas.

## Funcionalidades principales

- Mostrar Personajes: Se listaran los personajes extraidos del archivo hacia la lista de personajes actualizandola cada vez que se la muestre ya que puede darse el caso de que se hayan realizados cambios en la misma.
- Iniciar un combate: Se ingresara el id de alguno de los personajes disponibles para luchar contra un personaje aleatorio propuesto por el juego, luego de cada ataque se mostrara la informacion del daño realizado y la vida restante. Por ultimo se muestra el ganador de la pelea.
- Agregar un personaje: Se podra crear un personaje con las caracteristicas ingresadas y se ofrece la posibilidad de almacenarlo en el archivo csv, de lo contrario su tiempo de existencia terminara cuando se salga del juego.
- Modificar personajes: Cambiar los valores de los atributos de un personaje tambien dando la posibilidad de guardarlo en el archivo csv.
