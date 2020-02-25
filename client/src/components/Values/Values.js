import React,{Component} from 'react';
import {VerticalGridLines,HorizontalGridLines,XAxis,XYPlot,YAxis,LineSeries} from 'react-vis';

export default class Values extends Component{
    constructor(props){
        super(props);
        this.state = {
            values:[]
        }
    }

    componentDidUpdate(prevProps){
        if(this.props.values!==prevProps.values){
            this.setState({
                values:this.props.values.map(value =>{
                    return {x:value[0],y:value[1]}

                })
            })
            
        }
    }
    render(){
        
        return(
            <section className="Values container">
                <XYPlot height={600} width={800}>
                <VerticalGridLines />
                <HorizontalGridLines />
                <XAxis />
                <YAxis />
                <LineSeries data={this.state.values} />
                
                </XYPlot>
                <table className="highlight responsive-table">
                <thead>
                    <tr>
                        <th>X</th>
                        <th>Y</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.values.map(({x,y})=>{
                        return <tr key={x}>
                            <td>{x}</td>
                            <td>
                            {y}
                            <a  className="secondary-content"> <i className="small material-icons Sub-icons">delete</i></a>
                            <a  className="secondary-content"><i className="small material-icons Sub-icons">mode_edit</i></a>
                            </td>
                        </tr>
                    })}
                </tbody>
                </table>
                
            </section>
        )
    }
}