import React,{Component} from 'react';

export default class SubInfo extends Component{
    render(){
        
        return(
            <section className="collection with-header">
                <h4 className="collection-header">Информация</h4>
                <h5>{this.props.info[0].prop.name}</h5>
                <p>{this.props.info[0].prop.descr}</p>
                <hr></hr>
                <h6>{this.props.info[0].minValue}</h6>
                <h6>{this.props.info[0].maxValue}</h6>
                <h6>{this.props.info[0].defaultValue}</h6>
                
                <hr></hr>
                <h5>{this.props.info[1][0].stateVar.name}</h5>
                <p>{this.props.info[1][0].stateVar.descr}</p>
                <p>{this.props.info[1][0].stateVar.stateVarUnit}</p>
                <p>{this.props.info[1][0].versionDate}</p>
                <hr></hr>
            </section>
        )
    }
}