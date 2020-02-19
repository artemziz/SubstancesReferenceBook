import React,{Component} from 'react';


export default class AddPanel extends Component{

    render(){
        return(
            <div className="AddPanel">
            <div className="AddPanel-form">
                <form>
                <h6>Введите</h6>
                <div className="row">
                    <div className="input-field col s6">
                    <input placeholder="Placeholder" id="first_name" type="text" className="validate"/>
                    <label htmlFor="first_name">Название</label>
                    </div>
                </div>
                <div className="row">
                    <div className="input-field col s6">
                    <input id="last_name" type="text" className="validate"/>
                    <label htmlFor="last_name">Описание</label>
                    </div>
                </div>
                </form>
            </div>
            </div>
        )
    }
}