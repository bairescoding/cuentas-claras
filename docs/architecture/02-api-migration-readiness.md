# 🔌 Preparación para Consumo y Migración de APIs

Aunque inicialmente el proyecto pueda consumir datos estáticos, la arquitectura está preparada para escalar hacia APIs robustas de terceros o desarrollo de bajo código (Supabase, Firebase, .NET Minimal APIs).

## Principios
1. **Inyección de Dependencias**: Toda recuperación de datos, incluso el acceso a `.json` locales, debe abstraerse detrás de interfaces (ej. `IProductService`).
2. **DTOs (Data Transfer Objects)**: Los contratos de datos deben estar desacoplados del modelo de interfaz gráfica.
3. **Manejo de Errores Global**: Se debe incorporar un handler genérico para conexiones HttpClient que gestione estados de offline, timeouts y errores 500, asegurando una experiencia de usuario ininterrumpida (Offline PWA Features).
