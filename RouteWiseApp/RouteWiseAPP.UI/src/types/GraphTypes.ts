export interface Edge {
    targetNode: ParentNode;
    weight: number;
  }
  
  export interface ParentNode {
    name: string;
    edges: Edge[];
  }
  
  export interface ShortestPathResponse {
    distance: number;
    nodeNames: string[];
  }
  
  export interface GraphComponentProps {
    graphData: ParentNode[];
    shortestPath: ShortestPathResponse;
  }

  export interface SearchResultObject{
    fromNode: string;
    toNode: string;
    distance: number;
    nodeNames: string[];
  }

  export interface SearchProps {
    fromNode: string;
    toNode: string;
  }
