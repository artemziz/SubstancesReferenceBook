import React,{Component} from 'react';
import {VerticalGridLines,HorizontalGridLines,XAxis,XYPlot,YAxis,LineSeries} from 'react-vis';

export default class Values extends Component{
    render(){
        const data = [
            {x: 0, y: 8},
            {x: 1, y: 5},
            {x: 2, y: 4},
            {x: 3, y: 9},
            {x: 4, y: 1},
            {x: 5, y: 7},
            {x: 6, y: 6},
            {x: 7, y: 3},
            {x: 8, y: 2},
            {x: 9, y: 0}
          ];
        return(
            <section className="Values container">
                <XYPlot height={600} width={800}>
                <VerticalGridLines />
                <HorizontalGridLines />
                <XAxis />
                <YAxis />
                <LineSeries data={data} />
                </XYPlot>
                <table className="highlight responsive-table">
                <thead>
                    <tr>
                        <th>X</th>
                        <th>Y</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(({x,y})=>{
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