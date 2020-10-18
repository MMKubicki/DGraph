# Changelog

## Planned
- Condition node
    - Branch depending on condition outside of a text choice
- Action node
    - Run an action on activation of node
- Removing duplication of code from NodeEditors and NodeInspectors

## 1.0.0-preview.4
- UPDATE:
    - xNode 1.7 -> 1.8.0
    - Unity 2019.3 -> 2019.4
- FIX:
    - AdditionalData in TextNodes was not initialized at spawn
    - TextNode Inspector now checks for situations when no characters are set
    - Temporary fix for deleting choices in ChoiceNodes: For the moment you can only delete the last choice

## 1.0.0-preview.3
- FIX Additional Data was not serialized

## 1.0.0-preview.2
- Additional Data:
    - Can add a additional data node to graph
    - injects additional information into text node

## 1.0.0-preview.1
- Basic functionality:
    - Conversation Graph
    - Basic validation
    - Characters
    - Text node
    - Choice node
    