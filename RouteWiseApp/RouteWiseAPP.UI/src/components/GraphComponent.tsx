import React, { useEffect, useState } from 'react';
import { ParentNode, GraphComponentProps, ShortestPathResponse } from '../types/GraphTypes';
import '../index.css';

const GraphComponent: React.FC<GraphComponentProps> = ({ graphData, shortestPath }) => {
  const [nodePositions, setNodePositions] = useState<{ [key: string]: { x: number; y: number } }>({});

  useEffect(() => {
    // Manually set node positions to match the provided graph layout
    const positions = {
      A: { x: 50, y: 150 },
      B: { x: 150, y: 50 },
      C: { x: 50, y: 250 },
      D: { x: 250, y: 250 },
      E: { x: 150, y: 150 },
      F: { x: 250, y: 50 },
      G: { x: 350, y: 200 },
      H: { x: 350, y: 50 },
      I: { x: 450, y: 150 },
    };
    setNodePositions(positions);
  }, []);

  return (
    <div className="graph-container">
      <h2 className="graph-title">Graph Visualization</h2>
      <svg className="graph-svg" width={500} height={300}>
        <defs>
          <marker id="arrowhead" markerWidth="10" markerHeight="7" refX="10" refY="3.5" orient="auto">
            <polygon points="0 0, 10 3.5, 0 7" />
          </marker>
        </defs>

        {/* Render edges */}
        {graphData.map((node) =>
          node.edges.map((edge, index) => {
            const fromPosition = nodePositions[node.name];
            const toPosition = nodePositions[edge.targetNode.name];

            if (!fromPosition || !toPosition) return null;

            const isPathHighlighted =
              shortestPath.nodeNames.includes(node.name) && shortestPath.nodeNames.includes(edge.targetNode.name);

            return (
              <g key={`${node.name}-${edge.targetNode.name}-${index}`}>
                <line
                  x1={fromPosition.x}
                  y1={fromPosition.y}
                  x2={toPosition.x}
                  y2={toPosition.y}
                  className={`edge ${isPathHighlighted ? 'highlighted-edge' : ''}`}
                  stroke={isPathHighlighted ? 'orange' : 'blue'}
                  strokeWidth={2}
                  markerEnd="url(#arrowhead)"
                />
                <text
                  x={(fromPosition.x + toPosition.x) / 2}
                  y={(fromPosition.y + toPosition.y) / 2 - 5}
                  fill="black"
                  fontSize="12"
                  textAnchor="middle"
                >
                  {edge.weight}
                </text>
              </g>
            );
          })
        )}

        {/* Render nodes */}
        {Object.entries(nodePositions).map(([nodeName, position]) => (
          <g key={nodeName}>
            <circle cx={position.x} cy={position.y} r={20} className="node" fill="lightblue" />
            <text x={position.x} y={position.y + 5} fill="black" fontSize="12" textAnchor="middle">
              {nodeName}
            </text>
          </g>
        ))}
      </svg>
    </div>
  );
};

export default GraphComponent;
