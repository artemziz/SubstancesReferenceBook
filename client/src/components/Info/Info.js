import React,{Component} from 'react';

export default class Info extends Component{
    render(){
        return(
            <section className="col s6 Info collection with-header">
                <h4 className="collection-header">Информация</h4>
                <h6>{this.props.info.name}</h6>
                <p>{this.props.info.descr}</p>
            </section>
        )
    }
}