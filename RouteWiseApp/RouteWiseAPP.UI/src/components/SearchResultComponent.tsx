import React, { useState } from "react";
import { ParentNode, SearchResultObject, ShortestPathResponse } from "../types/GraphTypes";

const SearchResultComponent: React.FC<SearchResultObject> = ({ fromNode, toNode, nodeNames, distance }) => {

    console.log('log1');
    console.log(nodeNames)

  return (
    <div>
      <h4 className="mb-4">Result</h4>
      <div className="p-3 border rounded bg-light">
        <p>From Node Name = "{fromNode}", To Node Name = "{toNode}"</p>
        <p>Path: {nodeNames.join(", ")}</p>
        <p>Total Distance: {distance}</p>
      </div>
    </div>
  );
};

export default SearchResultComponent;
