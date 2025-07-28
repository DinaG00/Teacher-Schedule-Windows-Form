# Teacher Schedule Project

A Windows Forms application for managing teacher schedules, rooms, and subjects. This project is designed to help educational institutions organize and visualize teaching schedules, room allocations, and subject assignments efficiently.

## Features

- Manage teachers, rooms, and subjects
- Create and edit schedules for teachers
- Assign rooms and subjects to teachers
- Visualize schedules in a tabular format
- Print and preview schedules
- Simple, user-friendly interface
- Data persistence using SQLite

### Prerequisites
- Windows OS
- [Visual Studio 2017 or later](https://visualstudio.microsoft.com/)
- .NET Framework 4.0 or later

## Project Structure
- `Entities/` - Data models for Teacher, Room, Subject, and Schedule
- `Resources/` - Forms and resources for schedule management
- `AddEditForm*.cs` - Forms for adding/editing entities
- `MenuForm.cs` - Main menu and navigation
- `ScheduleForm.cs` - Schedule visualization and printing
- `dbRooms.sqlite` - SQLite database file

## Dependencies
- [Control.Draggable](https://www.nuget.org/packages/Control.Draggable/) (for draggable UI elements)
- [System.Data.SQLite.Core](https://www.nuget.org/packages/System.Data.SQLite.Core/) (for SQLite database access)

Dependencies are managed via NuGet. See `packages.config` for details.

## Usage Example
1. Launch the application.
2. Use the main menu to navigate between Teachers, Subjects, and Rooms management.
3. Add or edit teachers, rooms, and subjects as needed.
4. Go to the Schedule section to assign teachers to rooms and subjects for specific days and times.
5. Print or preview the schedule as needed.

## Database
- The application uses a local SQLite database (`dbRooms.sqlite`) for data storage.
- The database file is copied to the output directory on build.

