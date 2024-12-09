# RouteWise App - Shortest Path Calculator

The **RouteWise App - Shortest Path Calculator** is a versatile application designed to find the most efficient route between points in a graph. Whether you're optimizing routes for logistics, navigating road networks, or solving graph-based problems, this app provides a robust and user-friendly solution.

## Key Features

- Clean Architecture design.
- CQRS implementation with **MediatR**.
- Dependency Injection for better testability and modularity.
- Automatic logging using **Serilog**.
- Easy-to-extend middleware for handling cross-cutting concerns.
- Responsive **React** frontend for user interaction.

---

### Clean Architecture Features

The Shortest Path Calculator is built using the principles of Clean Architecture to ensure scalability, maintainability, and separation of concerns. Key features of the architecture include:
- **Separation of Layers**:
  - **Domain Layer**: Contains core business logic and entities independent of external frameworks.
  - **Application Layer**: Handles use case implementations and acts as a bridge between the domain and infrastructure layers.
  - **Infrastructure Layer**: Manages external dependencies like databases, APIs, and file systems.
  - **Presentation Layer**: Provides the user interface and interacts with the application layer through APIs.
- **Dependency Rule**: Ensures that the core layers (Domain and Application) are independent of external frameworks, improving testability and adaptability.
- **Cross-Cutting Concerns**: Features like logging, exception handling, and authentication are implemented in a modular way to avoid code duplication.
- **Testability**: Each layer can be independently tested using unit tests and integration tests.

### Frontend APP 

- **Graph Representation**: Define graphs using nodes.
- **Algorithms Supported**:
  - Dijkstra's Algorithm
- **Interactive Visualization**: View and interact with graph structures and shortest paths using an intuitive UI.
- **Custom Input Options**: Input graph data through files - JSON
- **Multiple Use Cases**: Works for road networks, delivery optimizations, and academic graph problems.
- **Export Results**: Save calculated shortest paths and graph representations as reports or files.

### Console Application

The Shortest Path Calculator includes a Console Application for users who prefer a lightweight and command-line-driven experience. Key features of the Console App include

- **Simple Command Interface**: Interact with the application by providing inputs through terminal commands.
- **Enter Start & End Nodes**: Enter the start and end node name 
- **Result Display**: View shortest path results and cost directly in the terminal or save them to an output file.

### Tester Application - xUnit

To ensure the reliability and correctness of the Shortest Path Calculator, an xUnit-based Tester Application is included. It covers the following
- **Unit Tests**: Verifies individual components of the application

## How It Works

1. **Input Graph**: Define your graph by providing nodes, edges, and edge weights through the app's interface or by importing a file.
2. **Select Nodes**: Choose the start node and end node.
3. **Run Calculation**: The app computes the shortest path and provides a detailed result, including total path cost and intermediate nodes.
4. **Visualize Path**: See the calculated shortest path displayed graphically on the network.

## Technologies Used

- **Backend**: ASP.NET Core for high-performance API and computational logic.
- **Frontend**: React.js for a dynamic and responsive user interface.
- **Graph Algorithms**: Implemented in C# with optimized performance.

## Use Cases

- **Navigation Systems**: Calculate the fastest routes in road networks.
- **Logistics and Supply Chain**: Optimize delivery routes and resource allocation.
- **Graph Theory Problems**: Solve shortest path problems for academic or research purposes.
- **Network Optimization**: Analyze and optimize connectivity in network infrastructures.

## Getting Started

### Prerequisites

- API APP | APP.NET CORE Web API - net8.0 LTS
- Console APP | .NET CORE Console App - net8.0 LTS
- API Tester APP | .NET Core xUnit Test App - - net8.0 LTS
- Frontend APP | Node - v18.20.4 | React - react@18.3.1

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/tharindusandamal/RouteWiseApp.git
   cd RouteWiseApp
2. Set up the backend:
   ```bash
   cd RouteWiseAPP.API
   dotnet build
   dotnet run
3. Set up the frontend:
   ```bash
   cd RouteWiseAPP.UI
   npm install
   npm start
4. Open your browser and navigate to http://localhost:3000 to access the app.

### 

## Contributing

Contributions are welcome! To contribute:

- Fork the repository.
- Create a new branch for your feature or bug fix.
- Commit your changes and open a pull request.

## License

This project is licensed under the MIT License.




   







   
