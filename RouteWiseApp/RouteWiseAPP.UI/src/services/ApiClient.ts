
import axios from "axios";
import { ParentNode, ShortestPathResponse, SearchProps } from "../types/GraphTypes";

const API_BASE_URL = process.env.REACT_APP_API_BASE_URL || "https://localhost:7061";

// API client for fetching graph data
export const getGraphData = async (): Promise<ParentNode[]> => {
  try {
    const response = await axios.get<ParentNode[]>(`${API_BASE_URL}/api/v1/Nodes`);
    return response.data;
  } catch (error) {
    console.error("Error loading graph data:", error);
    throw error; 
  }
};

// API client for calculating the shortest path
export const calculateShortestPath = async (
  searchProps: SearchProps
): Promise<ShortestPathResponse> => {
  try {
    const response = await axios.post<ShortestPathResponse>(
      `${API_BASE_URL}/api/v1/Nodes/find`,
      {
        fromNodeName: searchProps.fromNode,
        toNodeName: searchProps.toNode,
      }
    );
    return response.data;
  } catch (error) {
    console.error("Error calculating shortest path:", error);
    throw error;
  }
};
