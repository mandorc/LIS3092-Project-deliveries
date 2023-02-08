# Pac-Man

Para el desarrollo de Pac-Man se buscó que el juego luciera lo más parecido al juego clasico, es decir, con un estilo pixeleado.

## Desarrollo de juego

- El laberinto se describe por un mapa en texto.
- Se tienen al menos 4 enemigos (fantasmas)
- El pac-man se puede mover por los ejes X y Y.
- Tiene la posibilidad de usar dos tuneles, es decir, una vía de escape en el extremo de la pantalla.
- Cuenta con secciones donde se puede ir moviendo mientras recolecta pastillas.
- Tiene un contador de puntaje por nivel y uno general para todos los niveles.
- Cuenta con tres niveles diferentes.

## Requisitos para  puntos extra
 
- Si tiene capsulas de invencibilidad con las cuales puede comerse a los enemigos al comerla por un lapso de tiempo.
- Si los enemigos pueden regenerarse después de cierto tiempo.
- Si los enemigos persiguen a pacman al estar en cierta distancia.
- Si los personajes están animados.

## Documentación

### Configuración del mapa

Las variables utilizadas dentro de la matriz para poder reconocer los elementos del juego son:

| Variable | Descripción                                                                        |
|:--------:|:---------------------------------------------------------------------------------- |
|    0     | Espacio vacio por donde pueden andar los caracteres y pacman.                      |
|    1     | Las paredes, nadie puede atravesarlas.                                             |
|    2     | Las monedas simples, cada que pacman recolecta una el score aumenta en 10.         |
|    3     | La super moneda da la habilidad de que pacman coma a los fantasmas por 5 segundos. |
|    4     | La puerta de los fantasmas, pacman no puede pasar por ahi pero los fantasmas si.   |
|    10    | Ubicación inicial del jugador.                                                     |
|    11    | Es el portal, te lleva a donde se encuentre el valor 12.                           |
|    12    | Es el portal, te lleva a donde se encuentre el valor 11.                           |
|    13    | Es el portal, te lleva a donde se encuentre el valor 14.                           |
|    14    | Es el portal, te lleva a donde se enceuntre el valor 13.                           |
|    90    | Fantasma amarillo.                                                                 |
|    91    | Fantasma verde.                                                                    |
|    92    | Fantasma rosa.                                                                     |
|    93    | Fantasma rojo.                                                                     |

### Algoritmos utilizados

- **[Distancia Manhattan](https://es.wikipedia.org/wiki/Geometr%C3%ADa_del_taxista):** Es utilzada por los fantasmas, permite que sepan la dirección a la que se tienen que mover para poder llegar a Pac-Man.
