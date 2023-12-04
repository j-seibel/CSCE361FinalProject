import React, { Component } from 'react';
import { DropTarget } from 'react-dnd';

const Types = {
    ITEM: 'CardContainer'
};

const dropSpotSource = {
    drop(props, monitor, component) {
        let item = monitor.getItem();
        item.column = props.Column;
        item.upperDrop = props.UpperDrop;

        return item;
      }
};

function collect(connect, monitor) {
    return {
        connectDropTarget: connect.dropTarget(),
        isOver: monitor.isOver(),
        canDrop: monitor.canDrop(),
        itemType: monitor.getItemType()
    };
}

class DropSpot extends Component {
    render() {
        const { connectDropTarget, isOver } = this.props;
        
        return connectDropTarget(
            <div
                style={{
                    width: '126px',
                    borderRadius: '5px',
                    height: '181px',
                    backgroundColor: isOver ? '#e4e8b2' : '#fff',
                    zIndex: this.props.Index,
                    position: this.props.Position,
                    top: !this.props.UpperDrop ? ((this.props.Index - 1) * 15) + this.props.ExtraTop : 0,
                    padding: '5px',
                    opacity: 0.75
                }}
            />
        );
    }
}

export default DropTarget(Types.ITEM, dropSpotSource, collect)(DropSpot);