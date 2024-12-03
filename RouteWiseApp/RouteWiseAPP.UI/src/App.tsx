import React, { useState, useEffect } from "react";
import axios from "axios";
import SearchComponent from "./components/SearchComponent";
import GraphComponent from "./components/GraphComponent";
import { ParentNode, ShortestPathResponse } from "./types/GraphTypes";

const App: React.FC = () => {
  const [graphData, setGraphData] = useState<ParentNode[]>([]);
  const [shortestPath, setShortestPath] = useState<ShortestPathResponse>();

  // Load initial graph data from the API
  useEffect(() => {
    const fetchGraphData = async () => {
      try {
        const response = await axios.get<ParentNode[]>("https://localhost:7061/api/v1/Nodes");
        setGraphData(response.data);
        console.log('graphData');
        console.log(graphData);
      } catch (error) {
        console.error("Error loading graph data:", error);
      }
    };
    fetchGraphData();
  }, []);

  const handleCalculate = async (fromNode: string, toNode: string) => {
    try {
      const response = await axios.post<ShortestPathResponse>("https://localhost:7061/api/v1/Nodes/find", {
        'fromNodeName' : fromNode,
        'toNodeName': toNode,
      });
      setShortestPath(response.data);
    } catch (error) {
      console.error("Error calculating shortest path:", error);
    }
  };

  return (
    <div>
      <h1>Dijkstra's Algorithm Calculator</h1>
      <SearchComponent graphData={graphData} onCalculate={handleCalculate} />
      <GraphComponent graphData={graphData} shortestPath={shortestPath || { nodeNames: [] }} />
    </div>
  );
};

export default App;
