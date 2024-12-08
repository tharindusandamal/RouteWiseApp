import React, { useState, useEffect } from "react";
import axios from "axios";
import SearchComponent from "./components/SearchComponent";
import GraphComponent from "./components/GraphComponent";
import { ParentNode, SearchProps, ShortestPathResponse } from "./types/GraphTypes";
import SearchResultComponent from "./components/SearchResultComponent";
import { getGraphData, calculateShortestPath } from "../src/services/ApiClient";

const App: React.FC = () => {
  const [graphData, setGraphData] = useState<ParentNode[]>([]);
  const [shortestPath, setShortestPath] = useState<ShortestPathResponse>();
  const [searchProp, setSearchProp] = useState<SearchProps>();

  // Load initial graph data from the API
  useEffect(() => {
    const fetchGraphData = async () => {
      try {
        const data = await getGraphData();
        setGraphData(data);

      } catch (error) {
        console.error("Error loading graph data:", error);
      }
    };
    fetchGraphData();
  }, []);

  const handleCalculate = async (fromNode: string, toNode: string) => {
    try {
      const searchProps: SearchProps = { fromNode: fromNode, toNode: toNode };
      setSearchProp(searchProps);
      const response = await calculateShortestPath({
        fromNode : fromNode,
        toNode: toNode,
      });
      setShortestPath(response);
    } catch (error) {
      console.error("Error calculating shortest path:", error);
    }
  };

  // Handle clear button click 
  const handleClearSearch = async () => {
    // Set from and to as empty
    setSearchProp({ fromNode: "", toNode: "", });
    // Set shortest path as empty
    setShortestPath({ distance: 0, nodeNames: [] });
  };

  return (
    <div>
      <div className="header">
        <div>
          <h1>RouteWise - Shortest Path Finder</h1>
          <p>
            Discovering Optimal Routes Through Nodes
          </p>
        </div>
      </div>

      <div className="container con-custom">
        <div className="row justify-content-center">
          <div className="col-lg-10">
            <div className="panel row row mt-2">
              <div className="col-md-6">
                {/* SEARCH DIV */}
                <SearchComponent
                  graphData={graphData}
                  onCalculate={handleCalculate}
                  onClear={handleClearSearch}
                />
              </div>
              <div className="col-md-6">
                {/* SEARCH RESULT */}
                <SearchResultComponent
                  fromNode={searchProp?.fromNode || ""}
                  toNode={searchProp?.toNode || ""}
                  distance={shortestPath?.distance || 0}
                  nodeNames={shortestPath?.nodeNames || []}
                />
              </div>
            </div>
            <div className="panel row mt-2">
              <div className="col-md-12">
                {/* GRAPH DIV */}
                <GraphComponent
                  graphData={graphData}
                  shortestPath={shortestPath || { distance: 0, nodeNames: [] }}
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default App;
