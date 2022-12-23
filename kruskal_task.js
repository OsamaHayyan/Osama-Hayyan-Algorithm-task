class UnionFind {
  constructor(nodes) {
    this.parent = {};
    nodes.forEach((node) => (this.parent[node] = node));
  }

  union(a, b) {
    let rootA = this.find(a);
    let rootB = this.find(b);

    // Roots are same so these are already connected.
    if (rootA === rootB) return;

    // Always make the element with smaller root the parent.
    if (rootA < rootB) {
      if (this.parent[b] != b) this.union(this.parent[b], a);
      this.parent[b] = this.parent[a];
    } else {
      if (this.parent[a] != a) this.union(this.parent[a], b);
      this.parent[a] = this.parent[b];
    }
  }

  find(a) {
    while (this.parent[a] !== a) {
      a = this.parent[a];
    }
    return a;
  }

  connected(a, b) {
    return this.find(a) === this.find(b);
  }
}

class Graph {
  constructor() {
    this.nodes = new Set();
    this.edges = [];
  }

  addNode(element) {
    this.nodes.add(element);
  }

  addEdge(node1, node2, weight) {
    this.edges.push({ node1: node1, node2: node2, weight: weight });
  }

  sort() {
    this.edges.sort((a, b) => a.weight - b.weight);
  }

  summation(graph) {
    let sum = 0;
    graph.forEach(({ weight }) => (sum += weight));
    return sum;
  }
  print() {
    this.edges.forEach((v) => console.log(v));
  }
}

function kruksal(g) {
  const unionFind = new UnionFind(g.nodes);
  const A = [];
  const vSets = {};
  g.nodes.forEach((node) => (vSets[node] = node));
  g.sort();
  g.edges.forEach((edge) => {
    if (!unionFind.connected(edge.node1, edge.node2)) {
      A.push(edge);
      unionFind.union(edge.node1, edge.node2);
    }
  });

  return { MST: A, Cost: g.summation(A) };
}

let g = new Graph();

g.addNode("A");
g.addNode("B");
g.addNode("C");
g.addNode("D");
g.addNode("E");
g.addNode("F");
g.addNode("G");

g.addEdge("A", "D", 4);
g.addEdge("A", "C", 100);
g.addEdge("A", "B", 3);
g.addEdge("B", "G", 9);
g.addEdge("C", "D", 3);
g.addEdge("D", "E", 8);
g.addEdge("E", "G", 50);
g.addEdge("E", "F", 10);

console.log(kruksal(g));
