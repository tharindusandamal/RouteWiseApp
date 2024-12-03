import React from "react";

interface NodeComponentProps {
  name: string;
}

const NodeComponent: React.FC<NodeComponentProps> = ({ name }) => {
  return <div className="node">{name}</div>;
};

export default NodeComponent;
