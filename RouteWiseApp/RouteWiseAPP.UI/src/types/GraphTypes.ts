export interface Edge {
    targetNode: ParentNode;
    weight: number;
  }
  
  export interface ParentNode {
    name: string;
    edges: Edge[];
  }
  
  export interface ShortestPathResponse {
    nodeNames: string[];
  }
  
  export interface GraphComponentProps {
    graphData: ParentNode[];
    shortestPath: ShortestPathResponse;
  }