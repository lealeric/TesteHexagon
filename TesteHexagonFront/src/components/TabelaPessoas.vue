<template>
  <v-container>
    <h1 class="text-center mb-4">Gerenciamento de Pessoas</h1>

    <!-- Formulário para Adicionar/Editar -->
    <v-card class="mb-4 pa-4">
      <v-row>
        <v-col cols="12" sm="4">
          <v-text-field v-model="pessoa.nome" label="Nome" outlined dense></v-text-field>
        </v-col>
        <v-col cols="12" sm="2">
          <v-text-field
            v-model="pessoa.idade"
            type="number"
            label="Idade"
            outlined
            dense
          ></v-text-field>
        </v-col>
        <v-col cols="12" sm="3">
          <v-text-field
            v-model="pessoa.estadoCivil"
            label="Estado Civil"
            outlined
            dense
          ></v-text-field>
        </v-col>
        <v-col cols="12" sm="3">
          <v-text-field v-model="pessoa.cpf" label="CPF" outlined dense></v-text-field>
        </v-col>
        <v-col cols="12" sm="4">
          <v-text-field v-model="pessoa.cidade" label="Cidade" outlined dense></v-text-field>
        </v-col>
        <v-col cols="12" sm="4">
          <v-text-field v-model="pessoa.estado" label="Estado" outlined dense></v-text-field>
        </v-col>
        <v-col cols="12" sm="4">
          <v-btn color="primary" block @click="salvarPessoa">
            {{ editando ? 'Atualizar' : 'Adicionar' }}
          </v-btn>
        </v-col>
      </v-row>
    </v-card>

    <!-- Tabela de Pessoas -->
    <v-data-table
      :headers="headers"
      :items="pessoas"
      :items-per-page="itensPorPagina"
      class="elevation-2"
    >
      <template #item.actions="{ item }">
        <v-btn icon color="blue" @click="editarPessoa(item)"> ✏️ </v-btn>
        <v-btn icon color="red" @click="removerPessoa(item.id)"> 🗑️ </v-btn>
      </template>
    </v-data-table>
  </v-container>
</template>

<script>
import axios from 'axios'

export default {
  data() {
    return {
      pessoas: [], // Lista de pessoas vinda da API
      pessoa: { nome: '', idade: '', estadoCivil: '', cpf: '', cidade: '', estado: '' },
      editando: false,
      itensPorPagina: 5,
      apiUrl: 'http://localhost:5000/api/pessoas', // URL da API em .NET
    }
  },
  computed: {
    headers() {
      return [
        { text: 'Nome', value: 'nome' },
        { text: 'Idade', value: 'idade' },
        { text: 'Estado Civil', value: 'estadoCivil' },
        { text: 'CPF', value: 'cpf' },
        { text: 'Cidade', value: 'cidade' },
        { text: 'Estado', value: 'estado' },
        { text: 'Ações', value: 'actions', sortable: false },
      ]
    },
  },
  methods: {
    async carregarPessoas() {
      try {
        const response = await axios.get(this.apiUrl)
        this.pessoas = response.data
      } catch (error) {
        console.error('Erro ao carregar pessoas:', error)
      }
    },
    async salvarPessoa() {
      if (this.editando) {
        await axios.put(`${this.apiUrl}/${this.pessoa.id}`, this.pessoa)
      } else {
        await axios.post(this.apiUrl, this.pessoa)
      }
      this.pessoa = { nome: '', idade: '', estadoCivil: '', cpf: '', cidade: '', estado: '' }
      this.editando = false
      this.carregarPessoas()
    },
    editarPessoa(pessoa) {
      this.pessoa = { ...pessoa }
      this.editando = true
    },
    async removerPessoa(id) {
      await axios.delete(`${this.apiUrl}/${id}`)
      this.carregarPessoas()
    },
  },
  mounted() {
    this.carregarPessoas()
  },
}
</script>

<style scoped>
.v-container {
  max-width: 900px;
  margin: auto;
}
</style>
