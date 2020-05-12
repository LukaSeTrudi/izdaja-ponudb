<template>
  <div class="home">
	<div class="upper">
		<form id="filters" method="POST">
			<input type="hidden" name="filter" value="neki">
			Storitev: <input type="text" name="storitev">
			Stranka: 
			<select name="stranka">
				<option value=""></option>
				<option v-for="s in stranke" :key="s.id" :value="s.ime">{{s.ime}}</option>
			</select>
			Delavec:
			<select name="delavec">
				<option value=""></option>
				<option v-for="s in delavci" :key="s.id" :value="s.ime">{{s.ime}}</option>
			</select>
			Stanje:
			<select name="stanje">
				<option value=""></option>
				<option v-for="s in stanja" :key="s.id" :value="s.stanje">{{s.stanje}}</option>
			</select>
			Filtriraj
			<input type="button" value="Filtriraj" @click="filter()">
		</form>
		<button>
		<JsonExcel :data="storitve">Export to excel</JsonExcel>
		</button>
	</div>
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
import JsonExcel from "vue-json-excel";

export default {
  name: 'Home',
  data() {
    return {
	storitve: [],
	stranke: [],
	stanja: [],
	delavci: [],
    };
  },
  methods: {
	filter() {
		fetch("https://izdaja-ponudb.herokuapp.com/dobi-ponudbe.php", {
		method: 'POST',
		body: new FormData(document.getElementById('filters')),
		})
		.then(response => response.json())
		.then(result => {
			this.storitve = result;
		});
	}
  },
  components: {
	JsonExcel,
  },
  created(){
    fetch("https://izdaja-ponudb.herokuapp.com/dobi-ponudbe.php")
    .then(response => response.json())
    .then(data => {
      this.storitve = data;
	});
	fetch("https://izdaja-ponudb.herokuapp.com/dobi-stanja.php")
	.then(response => response.json())
    .then(data => {
      this.stanja = data;
	});
	fetch("https://izdaja-ponudb.herokuapp.com/dobi-stranke.php")
	.then(response => response.json())
    .then(data => {
      this.stranke = data;
	});
	fetch("https://izdaja-ponudb.herokuapp.com/dobi-delavce.php")
	.then(response => response.json())
    .then(data => {
      this.delavci = data;
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

.upper {
	display: flex;
}
form.input, form.select {
	margin-right: 10px;
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
