# Custom Paint Program

## Overview
This project is a custom paint application built using WinForms in C#. It features a wide array of geometric shapes that users can create and manipulate, as well as tools for drawing and painting. The application has been carefully designed to work within the limitations of WinForms, using innovative techniques to achieve features typically not possible in this environment.

## Key Features
- **Shape Creation and Manipulation**: The program allows users to create various geometric shapes, such as stars, polygons, and parametric shapes, each customizable with real-time adjustments to parameters like size, color, and alpha values.
- **Custom UI Components**: The application includes a fully custom shape editor with a color wheel and sliders for real-time color adjustments. This was built from scratch to provide intuitive and immediate feedback to the user.
- **Advanced Painting Tools**: Users can draw on the canvas using tools like brushes, erasers, spray paint, and fountain pens, each with adjustable sizes and colors.
- **Form as Control Technique**: To overcome the limitations of WinForms, where controls cannot have true transparency, shapes are implemented as individual forms. This approach allows for overlapping shapes with transparent backgrounds, maintaining a visually seamless experience.
- **Custom Title Bar and UI Management**: A custom title bar replaces the default Windows title bar, allowing shapes to be drawn over the entire canvas without being obscured by standard window controls. The UI is carefully layered to ensure that important controls remain accessible.

## Techniques and Design Decisions
### Form as Control
A significant challenge in this project was the need for transparent controls, a feature not natively supported by WinForms. After thorough research, it was determined that the only way to achieve true transparency was to implement each shape as a separate form. This allows the shapes to overlap without any visual artifacts, maintaining the illusion of transparency and enabling a more fluid user experience.
Many features were used to remove the titlebars, shadows etc., so that shapes look like a regular control, but with transparency.

### Custom Color Wheel
The color wheel used in the shape editor was built entirely from scratch. It dynamically generates a color palette based on the HSV color model, providing users with an intuitive way to select colors. The wheel is paired with a value slider to adjust brightness, allowing for a wide range of color customization.

### Custom Title Bar
To further enhance the user experience, the standard Windows title bar was replaced with a custom title bar. This change ensures that shapes can be freely moved and resized across the entire screen without being restricted by the non-interactive areas of the window.
This was also required to force the title bar on top of the form-shapes. This is also true for the other UI elements.

### File Structure
- **MainForm.cs**: Manages the creation and interaction of shapes, as well as the painting tools.
- **Shape.cs and Derived Classes**: Defines the base Shape class and its numerous derived classes for different geometric shapes.
- **ShapeEditor.cs**: Provides a detailed UI for editing shape properties, including color, size, and other parameters.
- **ToolBarForm.cs**: Handles the toolbar where users select shapes and painting tools.
- **TitleBar.cs**: Custom title bar implementation that allows for fullscreen interaction and shape manipulation.
- **Utilities**: Includes helper classes such as ClickDragMover for form dragging and FormAsControlStyler for styling forms to behave like controls.

## Installation
To run this project, ensure you have .NET installed. Clone the repository and build the solution in your preferred IDE.

'''
git clone https://github.com/Austin-bryan/PaintProgram
''' 

### Usage
Launch the application, use the toolbar to create shapes, and use the shape editor to modify them. The painting tools allow you to draw directly on the canvas.

### Contributing
Contributions are welcome! Please submit a pull request or open an issue if you have ideas for new features or find bugs.

### Authors
This project was developed by Austin Bryan, Lucius Miller, and Noah Curtis as part of a Foundations in App Development course.
