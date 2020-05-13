import React from 'react';
import {useTable} from 'react-table'
import styled from 'styled-components'
import data from './tasks.json';

const Styles = styled.div `
  table {
    width: 100%;
    border-spacing: 0;
    border: 1px solid black;
    tr {
      :last-child {
        td {
          border-bottom: 0;
        }
      }
    }
    th,
    td {
      margin: 0;
      padding: 1rem;
      border-bottom: 1px solid black;
      border-right: 1px solid black;
      :last-child {
        border-right: 0;
      }
    }
  }
`

function Table({columns, data}) {
  const {getTableProps, getTableBodyProps, headerGroups, rows, prepareRow} = useTable({columns, data})

  // Render Data Table UI
  return (
    <table {...getTableProps()}>
      <thead>
        {headerGroups.map(headerGroup => (
          <tr {...headerGroup.getHeaderGroupProps()}>
            {headerGroup
              .headers
              .map(column => (
                <th {...column.getHeaderProps()}>{column.render('Header')}</th>
              ))}
          </tr>
        ))}
      </thead>
      <tbody {...getTableBodyProps()}>
        {rows.map((row, i) => {
          prepareRow(row);
          return (
            <tr {...row.getRowProps()}>
              {row
                .cells
                .map(cell => {
                  return <td {...cell.getCellProps()}>{cell.render('Cell')}</td>
                })}
            </tr>
          )
        })}
      </tbody>
    </table>
  )
}

function Patients() {

  const columns = [
    {
      Header: 'Name',
      accessor: 'Patient Name'
    }, {
      Header: 'Gender',
      accessor: 'gender'
    }, {
      Header: 'Age',
      accessor: 'Age'
    }, {
      Header: 'Date of Arrival',
      accessor: 'Date of Arrival'
    }
  ]

  return (
    <Styles>
      <Table
        data={data}
        columns={columns}
      />
    </Styles>
  )

}

export default Patients;