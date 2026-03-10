# 💰 Cuentas Claras

**Cuentas Claras** es un gestor de finanzas personales moderno, ultra-rápido y elegante, diseñado como una **PWA (Progressive Web App)** utilizando **Blazor WebAssembly** y **.NET 10**.

La aplicación permite llevar un control detallado de ingresos y egresos con un enfoque en la estética visual y la facilidad de uso, sin depender de un servidor dedicado para la persistencia básica (utiliza almacenamiento local y mocks para demostración).

---

## ✨ Características Principales

-   **Premium UI/UX:** Interfaz construida con **MudBlazor**, siguiendo principios de diseño vibrante, modo oscuro y micro-interacciones.
-   **PWA Nativa:** Instalable en dispositivos móviles y escritorio, con soporte offline básico.
-   **Blazor WASM:** Ejecución completa en el navegador para una experiencia SPA (Single Page Application) fluida.
-   **Clean Architecture:** Estructura de código organizada para escalabilidad y mantenibilidad.
-   **CI/CD:** Despliegue automatizado a GitHub Pages mediante GitHub Actions.

---

## 🚀 Inicio Rápido

### Requisitos Previos

-   [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
-   Un editor compatible (VS Code, Visual Studio o JetBrains Rider)

### Ejecución Local

1.  Clona el repositorio:
    ```bash
    git clone https://github.com/BairesCoding/cuentas-claras.git
    cd cuentas-claras
    ```

2.  Ejecuta la aplicación:
    ```bash
    dotnet watch
    ```

3.  Abre tu navegador en `https://localhost:5001` (o la URL indicada en la terminal).

---

## 🛠️ Tecnologías

-   **Framework:** .NET 10 (Blazor WebAssembly)
-   **UI Library:** [MudBlazor](https://mudblazor.com/)
-   **Estilos:** CSS Vanilla (para personalizaciones premium)
-   **Persistencia:** Mock Service (preparado para integración con API/Storage)

---

## 📂 Estructura del Proyecto

Para más detalles sobre las decisiones de diseño y organización del código, consulta la documentación técnica:

-   [🏗️ Estructura del Proyecto](docs/architecture/01-project-structure.md)
-   [🚀 Optimización PWA/WASM](docs/architecture/03-pwa-wasm-optimization.md)
-   [✨ Guías de Código Limpio](docs/guidelines/clean-code-refactoring.md)
-   [🔒 Mejores Prácticas de Seguridad](docs/guidelines/security-best-practices.md)

---

## 🤖 AI Vibe Coding

Este repositorio está optimizado para el desarrollo asistido por IA (**Vibe Coding**). Incluye **Skills** personalizadas para agentes como Antigravity y Claude:

-   `.agent/skills/blazor-pwa`: Arquitectura núcleo y flujos de trabajo de Blazor.
-   `.agent/skills/frontend-design`: Guías de estética y UX de alto nivel.

---

## 📄 Licencia

Este proyecto es de código abierto bajo la licencia MIT.
