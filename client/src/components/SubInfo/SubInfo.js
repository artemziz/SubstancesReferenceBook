import React,{Component} from 'react';

export default class SubInfo extends Component{
    render(){
        return(
            <section className="collection with-header">
                <h4 className="collection-header">Информация</h4>
                <h5>{this.props.info.name}</h5>
                <p>{this.props.info.descr}</p>
                <hr></hr>
                <h6>{this.props.info.category.name}</h6>
                <p>{this.props.info.category.descr}</p>
            </section>
        )
    }
}