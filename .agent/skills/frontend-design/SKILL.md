---
name: Frontend Design Aesthetics (MudBlazor)
description: Design Thinking and Aesthetics Guidelines for creating visually striking Blazor frontends using MudBlazor.
---

# Frontend Design Aesthetics - MudBlazor

Strictly follow these guidelines for any UI/UX related tasks in Blazor projects using MudBlazor.

## Framework Context
- **Target**: Blazor WebAssembly (.NET 8+)
- **Library**: MudBlazor v8+ (latest)
- **Baseline**: Material Design principles with intentional deviation
- **Constraints**: .NET runtime, CSS scoping, Blazor component lifecycle

**CRITICAL**: MudBlazor provides Material Design defaults - your job is to transform these into something UNFORGETTABLE. The library is a starting point, not a destination.

## Design Thinking
Before coding, understand the context and commit to a BOLD aesthetic direction:
- **Purpose**: What problem does this interface solve? Who uses it?
- **Tone**: Pick an extreme: brutally minimal, maximalist chaos, retro-futuristic, organic/natural, luxury/refined, playful/toy-like, editorial/magazine, brutalist/raw, art deco/geometric, soft/pastel, industrial/utilitarian, etc. design one that is true to the aesthetic direction.
- **Constraints**: Technical requirements (Blazor WASM performance, accessibility, MudBlazor component limitations).
- **Differentiation**: What makes this UNFORGETTABLE? What's the one thing someone will remember?

**CRITICAL**: Choose a clear conceptual direction and execute it with precision. Bold maximalism and refined minimalism both work - the key is intentionality, not intensity.

Implement working code that is:
- Production-grade and functional
- Visually striking and memorable
- Cohesive with a clear aesthetic point of view
- Meticulously refined in every detail

## MudBlazor Theming

### MudThemeProvider Setup
Always configure MudThemeProvider with a custom theme - never use defaults:

```razor
<MudThemeProvider Theme="@_customTheme" />

@code {
    private MudTheme _customTheme = new MudTheme()
    {
        Palette = new PaletteLight
        {
            Primary = "#FF6B35",        // Bold orange - not the default blue
            Secondary = "#004E89",     // Deep navy
            Tertiary = "#F7C59F",      // Warm peach
            AppbarBackground = "#1A1A2E",
            Background = "#0F0F1A",
            Surface = "#16213E",
            TextPrimary = "#EAEAEA",
        },
        PaletteDark = new PaletteDark
        {
            Primary = "#FF6B35",
            Secondary = "#2EC4B6",
            Tertiary = "#FF9F1C",
            AppbarBackground = "#0D0D0D",
            Background = "#000000",
            Surface = "#1A1A1A",
            TextPrimary = "#FFFFFF",
        },
        Typography = new Typography
        {
            Default = new FontFamily
            {
                Family = new[] { "Outfit", "Helvetica Neue", "sans-serif" }
            },
            H1 = new H1Font { FontFamily = new[] { "Playfair Display", "serif" } },
            H2 = new H2Font { FontFamily = new[] { "Playfair Display", "serif" } },
        }
    };
}
```

### Custom Palettes - Break the Default Blue
MudBlazor's default theme is blue/grey - intentionally deviate:
- **Primary**: Choose a bold, memorable color (vibrant orange, electric purple, emerald green)
- **Secondary**: A contrasting accent that supports the primary
- **Tertiary**: A third color for highlights and variety
- **Avoid**: Evenly distributed palettes - bold designs have dominant colors with sharp accents

### Typography Override
Add custom fonts via `wwwroot/index.html` (WASM):

```html
<link href="https://fonts.googleapis.com/css2?family=Outfit:wght@300;400;600;700&family=Playfair+Display:wght@400;700&display=swap" rel="stylesheet">
```

Then configure in theme:

```razor
Typography = new Typography
{
    Default = new FontFamily { Family = new[] { "Outfit", "sans-serif" } },
    H1 = new H1Font { FontFamily = new[] { "Playfair Display", "serif" }, FontSize = "4rem" },
    // ... other overrides
}
```

### Elevation and Shadows
Override default shadows for a unique look:

```razor
Shadows = new Shadow[]
{
    new Shadow(0, 0, 0, 0, "none"),
    new Shadow(0, 1, 3, 0, "0 1px 3px rgba(0,0,0,0.12)"),
    new Shadow(0, 4, 6, 0, "0 10px 20px rgba(255, 107, 53, 0.15)"), // Custom
    // ... custom shadows
}
```

## Component Customization

### CSS Variables
Use MudBlazor's CSS variables for targeted overrides:

```css
:root {
    --mud-palette-primary: #FF6B35;
    --mud-palette-secondary: #2EC4B6;
    --mud-palette-surface: #1A1A2E;
    --mud-default-border-radius: 0px;  /* Brutalist sharp corners */
}
```

### Scoped Component Overrides
Create memorable custom components:

```razor
@* CustomButton.razor *@
@inherits MudButton

<MudButton Class="custom-bold-button" @attributes="InputAttributes">
    @ChildContent
</MudButton>

<style>
    .custom-bold-button {
        border-radius: 0 !important;
        font-weight: 700 !important;
        letter-spacing: 0.1em !important;
        text-transform: uppercase !important;
        transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1) !important;
    }
    
    .custom-bold-button:hover {
        transform: translateY(-2px);
        box-shadow: 0 10px 30px rgba(255, 107, 53, 0.4) !important;
    }
</style>
```

### MudGlobal - Use Sparingly
As of MudBlazor v8+, global theming properties are deprecated. Prefer:
- Component-level parameters for Color, Variant, Rounded
- Custom CSS themes
- Component inheritance for reusable patterns

## Frontend Aesthetics Guidelines

Focus on these elements while respecting MudBlazor's component model:

### Typography
- Choose fonts that are beautiful, unique, and interesting. Avoid generic fonts like Arial and Inter
- Pair a distinctive display font (Playfair Display, Clash Display, Satoshi) with a refined body font (Outfit, DM Sans, Plus Jakarta Sans)
- Configure typography in the theme, override per-component when needed

### Color & Theme
- Commit to a cohesive aesthetic using CSS variables and custom Palettes
- Dominant colors with sharp accents outperform timid, evenly-distributed palettes
- Use MudThemeProvider for global colors, CSS overrides for specific components
- Test both Light and Dark mode - both should feel intentional

### Motion
- Use MudTransition for component state changes
- Add CSS animations for micro-interactions
- Prioritize CSS-only solutions - Blazor re-renders can conflict with JS animations
- Focus on high-impact moments: staggered reveals, hover states, page transitions
- Example:
```css
@keyframes fadeInUp {
    from { opacity: 0; transform: translateY(20px); }
    to { opacity: 1; transform: translateY(0); }
}

.mud-card-content > * {
    animation: fadeInUp 0.5s ease-out forwards;
    opacity: 0;
}

.mud-card-content > *:nth-child(1) { animation-delay: 0.1s; }
.mud-card-content > *:nth-child(2) { animation-delay: 0.2s; }
.mud-card-content > *:nth-child(3) { animation-delay: 0.3s; }
```

### Spatial Composition
- Unexpected layouts using MudGrid, custom CSS Grid
- Asymmetry: offset elements, diagonal flows
- Overlap: layered components with z-index
- Generous negative space OR controlled density - commit to one extreme
- Break grid constraints intentionally with custom margins/padding

### Backgrounds & Visual Details
- Create atmosphere using gradient meshes, noise textures, geometric patterns
- Use layered transparencies and custom shadows
- Avoid default solid backgrounds - customize Surface colors
- Add grain overlays, decorative borders, custom cursors for depth

**NEVER** use generic AI-generated aesthetics like:
- Overused font families (Inter, Roboto, Arial)
- The default MudBlazor blue theme
- Predictable Material Design layouts
- Cookie-cutter design

**IMPORTANT**: Match implementation complexity to the aesthetic vision. Maximalist designs need elaborate code with extensive animations. Minimalist designs need restraint, precision, and careful attention to spacing and subtle details.

## Anti-Patterns to Avoid

1. **Using the Default Theme**: Never ship with the default blue MudBlazor theme
2. **Under-customization**: Changing only Primary color is not enough
3. **Ignoring Dark Mode**: Both themes should be thoughtfully designed
4. **Inline Styles**: Use theme configuration and CSS classes instead
5. **Forgetting Typography**: The default typography is generic
6. **Material Design Clones**: MudBlazor is Material-based - your job is to evolve beyond it
7. **No Motion**: Static interfaces are forgettable

## Examples

### Brutalist Dark Theme
```razor
<MudThemeProvider Theme="@_brutalistTheme" />

@code {
    private MudTheme _brutalistTheme = new MudTheme()
    {
        Palette = new PaletteLight
        {
            Primary = "#000000",
            Secondary = "#FF0000",
            Tertiary = "#FFFF00",
            AppbarBackground = "#000000",
            Background = "#F5F5F5",
            Surface = "#FFFFFF",
            TextPrimary = "#000000",
            TextSecondary = "#666666",
        },
        DefaultBorderRadius = 0,
        Typography = new Typography
        {
            Default = new FontFamily { Family = new[] { "Space Mono", "monospace" } },
            H1 = new H1Font { FontFamily = new[] { "Oswald", "sans-serif" }, FontSize = "5rem", TextTransform = "uppercase" },
        }
    };
}
```

### Luxury Minimal Theme
```razor
<MudThemeProvider Theme="@_luxuryTheme" />

@code {
    private MudTheme _luxuryTheme = new MudTheme()
    {
        Palette = new PaletteLight
        {
            Primary = "#1A1A1A",
            Secondary = "#C9A227",  // Gold accent
            Tertiary = "#8B7355",   // Bronze
            AppbarBackground = "#FFFFFF",
            Background = "#FAFAFA",
            Surface = "#FFFFFF",
            TextPrimary = "#1A1A1A",
            DrawerBackground = "#F0F0F0",
        },
        DefaultBorderRadius = 2,
        Shadows = new Shadow[] { /* subtle, refined shadows */ },
        Typography = new Typography
        {
            Default = new FontFamily { Family = new[] { "Cormorant Garamond", "serif" } },
            H1 = new H1Font { FontFamily = new[] { "Cormorant Garamond", "serif" }, FontWeight = 300 },
        }
    };
}
```
