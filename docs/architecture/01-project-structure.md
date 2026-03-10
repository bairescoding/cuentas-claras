# 🏗️ Estructura del Proyecto: Blazor WASM PWA

Este documento establece el contrato arquitectónico de la aplicación.

## Fundamentos
- El frontend debe ser desarrollado utilizando **Blazor WebAssembly** puro sin requerir de hosting server-side (SPA).
- Para el estilo visual, se prioriza el código modular, colores vivos, soporte para modo oscuro, y animaciones sutiles (Micro-interactions).

## Organización de Componentes
1. **Páginas (`/Pages`)**: Contendrá únicamente los enrutadores y controladores de vista de alto nivel.
2. **Componentes (`/Components`)**: Archivos independientes y reutilizables. Nada de HTML duplicado. Si se usan más de dos veces, se extraen a un componente.
3. **Servicios (`/Services`)**: Lógica de negocio y clientes HTTP.
4. **Estado (`/Store` o relativo)**: Cualquier estado global debe gestionarse a través de patrones consistentes (inyección de dependencias como Singleton/Scoped) para mantener sincronía entre componentes.
