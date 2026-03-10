# 🛠️ Infraestructura y Herramientas (Skills & CI/CD)

Este documento detalla los componentes tecnológicos y procesos de automatización que sostienen el proyecto **Cuentas Claras**.

## 🤖 AI Skills

El repositorio está configurado con **Skills** específicas para potenciar el desarrollo asistido por IA (Vibe Coding). Estas habilidades permiten a los agentes de IA entender profundamente el contexto del proyecto.

### [Blazor WASM PWA Vibe Coding Architect](.agent/skills/blazor-pwa/SKILL.md)
*   **Propósito:** Define las reglas de arquitectura núcleo para Blazor WASM.
*   **Enfoque:** Patrones de Clean Architecture, manejo de estado en el cliente y optimizaciones de PWA.
*   **Dependencias:** MudBlazor, .NET 10.

### [Frontend Design Aesthetics](.agent/skills/frontend-design/SKILL.md)
*   **Propósito:** Guía de diseño artístico y funcional.
*   **Enfoque:** Uso de gradientes, micro-interacciones, tipografía moderna y paletas de colores armónicas para lograr un acabado "Premium".

---

## 🎡 Flujo de CI/CD

El proyecto utiliza **GitHub Actions** para garantizar la calidad y el despliegue continuo.

### Pipeline: CI/CD GitHub Pages (`ci-cd-gh-pages.yml`)
Este flujo se activa automáticamente al realizar un push a la rama `main`.

1.  **Checkout:** Obtiene el código fuente.
2.  **Setup .NET:** Configura el entorno con la versión necesaria (.NET 10).
3.  **Restore & Build:** Restaura dependencias y compila el proyecto.
4.  **Publish:** Genera los archivos estáticos listos para ser servidos.
5.  **Fixing Paths:** Ajusta las rutas del `index.html` (base href) para que el sitio funcione correctamente bajo el subdominio de GitHub Pages (`/cuentas-claras/`).
6.  **Deploy:** Despliega el contenido de la carpeta `wwwroot` a la rama `gh-pages`.

### Release Drafter (`release-drafter.yml`)
Gestiona automáticamente los borradores de versiones basados en las etiquetas de los Pull Requests, manteniendo un log de cambios organizado.

---

## 🛡️ Estándares de Código

*   **EditorConfig:** Se utiliza un archivo `.editorconfig` para mantener la consistencia en el espaciado, indentación y reglas de estilo de C#.
*   **Clean Code:** Se siguen las guías definidas en [Clean Code Guidelines](docs/guidelines/clean-code-refactoring.md).
