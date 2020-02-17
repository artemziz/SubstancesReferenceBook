import React,{Component} from 'react';


export default class AddPanel extends Component{

    render(){
        return(
            <div className="AddPanel">
                <form className="col s12">
                <div className="row">
                    <div className="input-field col s6">
                    <input placeholder="Placeholder" id="first_name" type="text" className="validate"/>
                    <label for="first_name">Название</label>
                    </div>
                    <div className="input-field col s6">
                    <input id="last_name" type="text" className="validate"/>
                    <label for="last_name">Описание</label>
                    </div>
                </div>
                </form>
            </div>
        )
    }
}