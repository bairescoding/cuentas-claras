# 🧹 Clean Code & Ruthless Refactoring

Para mantener la salud de este proyecto durante el uso continuo de inteligencia artificial generativa, se mandata un compromiso total con el **Ruthless Refactoring**.

## Reglas Innegociables
- **Proactividad IA**: Código no referenciado, variables no utilizadas y comentarios obsoletos DEBEN ser borrados sin piedad por el Agente. Nunca conservar código "por las dudas de que el usuario lo ocupe".
- **Separación de Responsabilidades**: Todo bloque `@code` en un archivo `.razor` que supere las 150-200 líneas debe ser segregado mediante una clase parcial o *Code-Behind* (ej. `Component.razor.cs`).
- **Nomenclatura**: Los nombres de funciones y variables SIEMPRE en Inglés (por estándar global de la industria .NET), a pesar de que la documentación, commits, y la interacción en PRs ocurra en Español. Favorecer nombres descriptivos extensos que revelen la *intención*.
