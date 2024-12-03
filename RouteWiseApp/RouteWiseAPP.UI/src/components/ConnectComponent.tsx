import React from "react";

interface ConnectComponentProps {
  from: string;
  to: string;
  isHighlighted: boolean;
}

const ConnectComponent: React.FC<ConnectComponentProps> = ({ from, to, isHighlighted }) => {
  return (
    <div className={`connection ${isHighlighted ? "highlighted" : ""}`}>
      {from} → {to}
    </div>
  );
};

export default ConnectComponent;
