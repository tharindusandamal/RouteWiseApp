using Microsoft.Extensions.Logging;
using Moq;
using RouteWiseApp.APPLICATION.Repositories;
using RouteWiseApp.APPLICATION.Services;
using RouteWiseApp.APPLICATION.UseCases.Nodes.Query.GetShortesPath;
using RouteWiseApp.DOMAIN.DomanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentAssertions;
using RouteWiseAPP.API.TEST.Models.Results;
using System.Collections;

namespace RouteWiseAPP.API.TEST.UseCases.Nodes
{
    public class GetShortestPathQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<INodePathFinder> _nodePathFinderMock;
        private readonly Mock<ILogger<GetShortesPathQueryHandler>> _loggerMock;
        private readonly GetShortesPathQueryHandler _handler;
        private List<Node> _graphNodes;

        public GetShortestPathQueryHandlerTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _nodePathFinderMock = new Mock<INodePathFinder>();
            _loggerMock = new Mock<ILogger<GetShortesPathQueryHandler>>();
            _handler = new GetShortesPathQueryHandler(_unitOfWorkMock.Object, _nodePathFinderMock.Object, _loggerMock.Object);
            InitiateNodes();
        }

        internal void InitiateNodes()
        {
            var graphNodes = new List<Node>
            {
                new Node { Name = "A",
                    Edges = new List<Edge> {
                        new Edge { TargetNode = new Node { Name = "B" }, Weight = 4 },
                        new Edge { TargetNode = new Node { Name = "C" }, Weight = 6 }
                    } },
                new Node { Name = "B",
                    Edges = new List<Edge> {
                        new Edge { TargetNode = new Node { Name = "F" }, Weight = 2 }
                    } },
                new Node { Name = "C",
                    Edges = new List<Edge> {
                        new Edge { TargetNode = new Node { Name = "A" }, Weight = 6 },
                        new Edge { TargetNode = new Node { Name = "D" }, Weight = 8 }
                    } },
                new Node { Name = "D",
                    Edges = new List<Edge>{
                        new Edge { TargetNode = new Node { Name = "C" }, Weight = 8 },
                        new Edge { TargetNode = new Node { Name = "E" }, Weight = 4 },
                        new Edge { TargetNode = new Node { Name = "G" }, Weight = 1 }
                    } },
                new Node { Name = "E",
                    Edges = new List<Edge>{
                        new Edge { TargetNode = new Node { Name = "B" }, Weight = 2 },
                        new Edge { TargetNode = new Node { Name = "F" }, Weight = 3 },
                        new Edge { TargetNode = new Node { Name = "D" }, Weight = 4 },
                        new Edge { TargetNode = new Node { Name = "I" }, Weight = 8 }
                    } },
                new Node { Name = "F",
                    Edges = new List<Edge>{
                        new Edge { TargetNode = new Node { Name = "B" }, Weight = 2 },
                        new Edge { TargetNode = new Node { Name = "E" }, Weight = 3 },
                        new Edge { TargetNode = new Node { Name = "G" }, Weight = 4 },
                        new Edge { TargetNode = new Node { Name = "H" }, Weight = 6 }
                    } },
                new Node { Name = "G",
                    Edges = new List<Edge>{
                        new Edge { TargetNode = new Node { Name = "D" }, Weight = 1 },
                        new Edge { TargetNode = new Node { Name = "F" }, Weight = 4 },
                        new Edge { TargetNode = new Node { Name = "G" }, Weight = 4 },
                        new Edge { TargetNode = new Node { Name = "H" }, Weight = 6 }
                    } },
                new Node { Name = "H",
                    Edges = new List<Edge>{
                        new Edge { TargetNode = new Node { Name = "F" }, Weight = 6 },
                        new Edge { TargetNode = new Node { Name = "G" }, Weight = 5 }
                    } },
                new Node { Name = "I",
                    Edges = new List<Edge>{
                        new Edge { TargetNode = new Node { Name = "E" }, Weight = 8 },
                        new Edge { TargetNode = new Node { Name = "G" }, Weight = 5 }
                    } }
            };
        }

        [Fact]
        public async Task Handle_ShouldReturnShortestPath_WhenValidRequestIsProvided()
        {
            var request = new GetShortesPathQuery
            {
                Request = new GetShortesPathQueryRequestDTO
                {
                    FromNodeName = "A",
                    ToNodeName = "D",
                    GraphNodes = _graphNodes
                }
            };

            // Arrange
            var query = new GetShortesPathQuery
            {
                Request = new GetShortesPathQueryRequestDTO
                {
                    FromNodeName = "A",
                    ToNodeName = "F",
                    GraphNodes = _graphNodes
                }
            };

            _nodePathFinderMock
            .Setup(n => n.ShortestPath(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Node>>()))
            .Returns(new ShortestPathData
            {
                Distance = 6,
                NodeNames = new List<string> { "A", "B", "F" }
            });

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Distance.Should().Be(6);
            result.NodeNames.Should().BeEquivalentTo(new List<string> { "A", "B", "F" });
        }
    }
}
