import React,{Component} from 'react';

export default class Prop extends Component{
    constructor(props){
        super(props);
        this.getValues = this.getValues.bind(this);
    }
    getValues(){
        this.props.getValues(this.props.Id);
    }
    render(){
        return(
            <li className="collection-item"><div>
                <a href="#" onClick={this.getValues}>{this.props.name}</a>
                <a  className="secondary-content"> <i className="small material-icons Sub-icons">delete</i></a>
                <a  className="secondary-content"><i className="small material-icons Sub-icons">mode_edit</i></a>
                
                </div>
                </li>
        )
    }
}