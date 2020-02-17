import React,{Component} from 'react';


export default class Sub extends Component{
    constructor(props){
        super(props);
        this.getProps = this.getProps.bind(this);   
    }

    getProps(){
  
        this.props.getProps(this.props.Id);
    }
    
    render(){
        return(
            
                <li className="collection-item"><div>
                <a href="#" onClick={this.getProps}>{this.props.name}</a>
                <a  className="secondary-content"> <i className="small material-icons Sub-icons">delete</i></a>
                <a  className="secondary-content"><i className="small material-icons Sub-icons">mode_edit</i></a>
                
                </div>
                </li>
             
        )
    }
}