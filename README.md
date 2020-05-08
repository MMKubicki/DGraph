# DGraph

Small dialog graph tool for Unity.

Contains functionality for Characters, Text and Choices.

## Requirements
- Unity 2019.3
- xNode 1.7 (https://github.com/Siccity/xNode)

## Usage
- Create Conversation Graph asset (Create/DGraph/ConversationGraph)
- in graph:
    - Create Characters and link them to the Character Collection node
    - Build dialog starting form Start node
- To use the graph:
    - Call GetIterator() on graph
    - Use Next() to get next node data
        - if the result is a text node you get the text and the speaking character
        - if the result is a choice node you get the choices and the speaking character
    - If the result was a choice use the Next(int) method to give the iterator the index of the chosen choice

## License

This package is licensed under MIT and Apache 2.0 License
