import React, { useState } from "react";
import { ParentNode, ShortestPathResponse } from "../types/GraphTypes";

interface SearchComponentProps {
  graphData: ParentNode[];
  onCalculate: (fromNode: string, toNode: string) => void;
}

const SearchComponent: React.FC<SearchComponentProps> = ({ graphData, onCalculate }) => {
  const [fromNode, setFromNode] = useState<string>("");
  const [toNode, setToNode] = useState<string>("");

  const handleCalculate = () => {
    if (fromNode && toNode) {
      onCalculate(fromNode, toNode);
    } else {
      alert("Please select both nodes.");
    }
  };

  const handleClear = () => {
    setFromNode("");
    setToNode("");
  };

  return (
    <div className="search-container">
      <h2>Select Path</h2>
      <div>
        <label>From Node:</label>
        <select value={fromNode} onChange={(e) => setFromNode(e.target.value)}>
          <option value="">Select Node</option>
          {graphData.map((node) => (
            <option key={node.name} value={node.name}>
              {node.name}
            </option>
          ))}
        </select>
      </div>
      <div>
        <label>To Node:</label>
        <select value={toNode} onChange={(e) => setToNode(e.target.value)}>
          <option value="">Select Node</option>
          {graphData.map((node) => (
            <option key={node.name} value={node.name}>
              {node.name}
            </option>
          ))}
        </select>
      </div>
      <button onClick={handleCalculate}>Calculate</button>
      <button onClick={handleClear}>Clear</button>
    </div>
  );
};

export default SearchComponent;
