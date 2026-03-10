# 🛡️ Seguridad Específica para Blazor WASM PWA

Dado que toda la lógica corre en el cliente / navegador, se asume que **ningún dato en la SPA es privado a menos que esté encriptado o detrás de un token de autorización validado remotamente**.

1. **Gestión de Sesiones**: Utilizar `AuthenticationStateProvider` nativo. No almacenar tokens JWT en texto plano en `localStorage` permanentemente si manipulan info sensible.
2. **Sanitización Naval**: Blazor automáticamente previene XSS renderizando textos adecuadamente, pero cualquier inserción de crudo (`MarkupString`) requiere auditoría manual inmediata.
3. **Content Security Policy (CSP)**: Configurar e instaurar reglas estrictas en el `wwwroot/index.html` limitando `script-src` y `connect-src` a dominios autorizados de confianza.
