import { Container, Table } from "react-bootstrap";
import UciteljService from "../services/UciteljService";
import { useEffect, useState } from "react";


export default function Ucitelji() {

    
const [Ucitelj, setUcitelj] = useState();

async function getUcitelji() {

    const response = await UciteljService.read('Ucitelji');
    if(!response.ok) {
        alert(response.data);
        return;
    }
    setUcitelj(response.data);
}

useEffect(()=>{
    getUcitelji();
}, []); 

    return(

        <Container>
            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>Učitelj</th>
                        <th>email</th>
                        <th>brojMobitela</th>
                    </tr>
                </thead>
                <tbody>
                    {Ucitelj && Ucitelj.map((entitet, index) =>(
                        <tr key={index}>
                         <td>{entitet.ime}</td>
                        </tr>
                    ))};
                </tbody>
            </Table>
        </Container>
    )
}