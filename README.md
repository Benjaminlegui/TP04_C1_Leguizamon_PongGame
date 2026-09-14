# Pong — TP04 C1

<img src="Assets/Art/Sprites/pong-background.png" width="418" alt="Pong" />

Pong local para dos jugadores, hecho en Unity 6 con URP.
Local two player Pong, made in Unity 6 with URP.

---

## Español

### Detalles del juego

Dos paletas, una pelota y el primero que llegue a 3 puntos gana. Cada punto arranca con una cuenta regresiva de 3 segundos y tiene un límite de 20 segundos: si se agota el tiempo, el punto se lo lleva el jugador del lado que está defendiendo.

A diferencia del Pong clásico, las paletas se mueven en los dos ejes dentro de su mitad de cancha, así que podés salir a buscar la pelota en lugar de esperarla.

La pelota acelera un 5% con cada golpe de paleta, con un techo para que el punto no se vuelva injugable. Las paletas cambian a un color aleatorio cada vez que pegan, y se ponen negras mientras tocan una pared.

### Cómo jugar

| | Jugador 1 | Jugador 2 |
|---|---|---|
| Arriba | `W` | `↑` |
| Abajo | `S` | `↓` |
| Izquierda | `A` | `←` |
| Derecha | `D` | `→` |

* `Esc`: pausar y reanudar

La pausa funciona también durante la cuenta regresiva entre puntos: el contador queda congelado y retoma donde estaba al reanudar.

### Configuración

Desde el menú de settings, disponible tanto en el menú principal como en la pausa:

* **Por jugador:** velocidad, tamaño de la paleta y color
* **Partida:** duración de la ronda y cantidad de rondas (best of)

Los cambios se aplican en vivo, sin reiniciar el punto.

---

## English

### Game details

Two paddles, one ball, first to 3 points wins. Every point starts with a 3 second countdown and runs on a 20 second limit: if the time runs out, the point goes to the player on the defending side.

Unlike classic Pong, paddles move on both axes within their own half of the field, so you can go after the ball instead of waiting for it.

The ball speeds up by 5% on every paddle hit, capped so rallies stay playable. Paddles pick a random color each time they hit the ball, and turn black while touching a wall.

### How to play

| | Player 1 | Player 2 |
|---|---|---|
| Up | `W` | `↑` |
| Down | `S` | `↓` |
| Left | `A` | `←` |
| Right | `D` | `→` |

* `Esc`: pause and resume

Pausing works during the between-points countdown too: the counter freezes and picks up where it left off.

### Settings

From the settings menu, available both in the main menu and while paused:

* **Per player:** speed, paddle size and color
* **Match:** round length and number of rounds (best of)

Changes apply live, without restarting the point.

---

### Desarrollado por / Developed by

Benjamín Leguizamón

### Motor / Engine

Unity 6000.3.21f1 — Universal Render Pipeline

### Créditos / Credits

* **[2D Simple UI Pack](https://oarielg.itch.io/2d-simple-ui-pack)** — Ariel Oliveira (OArielG)
* **[Pixeloid](https://ggbot.itch.io/pixeloid-font)** — GGBotNet
* **TextMesh Pro** — Unity Technologies
