import React, { useState } from "react";
import { ParentNode, ShortestPathResponse } from "../types/GraphTypes";

interface SearchComponentProps {
  graphData: ParentNode[];
  onCalculate: (fromNode: string, toNode: string) => void;
  onClear: () => void;
}

const SearchComponent: React.FC<SearchComponentProps> = ({ graphData, onCalculate, onClear }) => {
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
    onClear();
  };

  return (
    <div>
      <h4 className="mb-4">Select Path</h4>
      <div className="mb-3">
        <label className="form-label">From Node</label>
        <select
          className="form-select"
          id="fromNode"
          value={fromNode}
          onChange={(e) => setFromNode(e.target.value)}
        >
          <option value="">Select Node</option>
          {graphData.map((node) => (
            <option key={node.name} value={node.name}>
              {node.name}
            </option>
          ))}
        </select>
      </div>
      <div className="mb-3">
        <label className="form-label">To Node</label>
        <select
          className="form-select"
          id="toNode"
          value={toNode}
          onChange={(e) => setToNode(e.target.value)}
        >
          <option value="">Select Node</option>
          {graphData.map((node) => (
            <option key={node.name} value={node.name}>
              {node.name}
            </option>
          ))}
        </select>
      </div>
      <div className="d-flex gap-2">
        <button
          onClick={handleClear}
          type="reset"
          className="btn btn-outline-danger"
        >
          Clear
        </button>
        <button
          onClick={handleCalculate}
          type="button"
          className="btn btn-custom"
        >
          <i className="bi bi-calculator"></i> Calculate
        </button>
      </div>
    </div>
  );
};

export default SearchComponent;
