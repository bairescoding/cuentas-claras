# ⚡ Optimización PWA y WebAssembly (WASM)

Para asegurar que nuestra aplicación Blazor WebAssembly PWA entregue el rendimiento de una aplicación nativa, es imperativo adherirse a las siguientes directrices de optimización en todo momento.

## 1. Compilación Ahead-of-Time (AOT)

La compilación AOT transforma el código .NET en WebAssembly nativo antes de descargarlo en el navegador. Esto incrementa drásticamente el rendimiento computacional, aunque aumenta ligeramente el tamaño de descarga.

- **Obligatorio para Producción:** Todos los builds de salida a producción deben estar compilados con AOT (`<RunAOTCompilation>true</RunAOTCompilation>`).
- **Uso Crítico:** Es especialmente importante para cálculos pesados en el cliente, serialización extensa de JSON, o manipulación de UI de alto rendimiento.

## 2. Trimming (Recorte de dependencias)

Con el fin de mitigar el tamaño de las descargas y acelerar el tiempo de inicio interactivo (Time to Interactive), se debe utilizar un nivel agresivo de trimming.

- **Configuración:** Utiliza `<PublishTrimmed>true</PublishTrimmed>`.
- **Cuidado con la Reflección:** Si algún componente dinámico o librería usa "Reflection" u otros accesos indirectos al código, asegúrate de utilizar el archivo de configuración XML de root (`TrimmerRootDescriptor` o directivas en el código) para evitar recortar tipos que son necesarios en tiempo de ejecución.

## 3. Comportamiento del Service Worker

Al ser una Progressive Web App, el Service Worker controla la cache y el soporte offline.

- **Cache-First para Assets Estáticos:** Framework, CSS, fuentes e imágenes inmutables.
- **Network-First (o Stale-while-revalidate) para Datos:** Cualquier petición a la API o archivo JSON dinámico debe apuntar primero a la red, rellenando con la caché si el usuario está Offline.
- **Actualizaciones Silenciosas:** Implementar flujos donde el navegador descargue la nueva versión del cliente en segundo plano y avise al usuario ("Nueva versión disponible. Refrescar"). No forzar recargas interruptivas.
