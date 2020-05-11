<template>
  <div class="home">
    <table>
      <thead>
        <th>Storitev</th>
        <th>Opis</th>
        <th>Cena</th>
        <th>Datum</th>
        <th>Stranka</th>
        <th>Izdal</th>
        <th>Stanje</th>
      </thead>
      <tbody>
        <tr v-for="storitev in storitve" :key="storitev.id">
          <td>{{storitev.storitev}}</td>
          <td>{{storitev.opis}}</td>
          <td>{{storitev.cena}}</td>
          <td>{{storitev.datum}}</td>
          <td>{{storitev.stranka_ime}}</td>
          <td>{{storitev.delavec_ime}}</td>
          <td>{{storitev.stanje}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: 'Home',
  data() {
    return {
      storitve: [],
    };
  },
  created(){
    fetch("https://izdaja-ponudb.herokuapp.com/dobi-ponudbe.php")
    .then(response => response.json())
    .then(data => {
      this.storitve = data;
    });
  }
  
}
</script>

<style>
table {
	width: 100%;
	border-collapse: collapse;
	margin: 50px auto;
}


/* Zebra striping */

tr:nth-of-type(odd) {
	background: #eee;
}

th {
	background: #3498db;
	color: white;
	font-weight: bold;
}

td,
th {
	padding: 10px;
	border: 1px solid #ccc;
	text-align: left;
	font-size: 18px;
}


/* 
Max width before this PARTICULAR table gets nasty
This query will take effect for any screen smaller than 760px
and also iPads specifically.
*/

@media only screen and (max-width: 760px),
(min-device-width: 768px) and (max-device-width: 1024px) {
	table {
		width: 100%;
	}
	/* Force table to not be like tables anymore */
	table,
	thead,
	tbody,
	th,
	td,
	tr {
		display: block;
	}
	/* Hide table headers (but not display: none;, for accessibility) */
	thead tr {
		position: absolute;
		top: -9999px;
		left: -9999px;
	}
	tr {
		border: 1px solid #ccc;
	}
	td {
		/* Behave  like a "row" */
		border: none;
		border-bottom: 1px solid #eee;
		position: relative;
		padding-left: 50%;
	}
	td:before {
		/* Now like a table header */
		position: absolute;
		/* Top/left values mimic padding */
		top: 6px;
		left: 6px;
		width: 45%;
		padding-right: 10px;
		white-space: nowrap;
		/* Label the data */
		content: attr(data-column);
		color: #000;
		font-weight: bold;
	}
}
</style>
