const app = Vue.createApp({
    data() {
        return {
            urlApi: 'https://localhost:7114/',
            titulo: 'Balanço mensal do Restaurante',
            showModel: false,
            showRegistro: false,
            valorSaida: null,
            pratoEscolhido: null,
            listaPratos: [],
            listaBalanco: [],
            prato: {
                nomePrato: "",
                descricaoPrato: "",
                valorPrato: 0,
                idCategoriaPrato: 1
            },
            balanco: {
                valor: null,
                tipoBalanco: null,
                idPrato: null
            },
            opcoesBalanco: [
                { text: 'Entrada', value: 'entrada'},
                { text: 'Saída', value: 'saida'},
            ],
            opcao: ''
        };
    },

    async created() {
        await Promise.all([
            this.listarPratos(),
            this.listarBalanco()
        ])
    },
    
    computed: {
        totalBalancoVendas() {
            let total = this.listaBalanco.filter(x => x.tipoBalanco == 1).map(x => Number(x.valor))
            if(total.length > 0) {
                return total.reduce((a, b) => a + b)
            }
            
            return 0;
        },

        totalBalancoSaida() {
            let total = this.listaBalanco.filter(x => x.tipoBalanco == 2).map(x => Number(x.valor))
            if(total.length > 0) {
                return total.reduce((a, b) => a + b)
            }
            
            return 0;
        }
    },

    methods: {
        saldoFinal() {
            return this.totalBalancoVendas - this.totalBalancoSaida
        },
        
        mostrarModal() {
            this.prato = {
                nomePrato: "",
                descricaoPrato: "",
                valorPrato: 0,
                idCategoriaPrato: 1
            }

            this.showModel = true
        },

        registrarBalanco() {
            this.balanco = { valor: null, tipoBalanco: null, idPrato: null}
            this.pratoEscolhido = null
            this.valorSaida = null
            this.showRegistro = true
        },

        salvarBalanco() {
            if(this.pratoEscolhido) {
                this.balanco = { 
                    valor: this.pratoEscolhido.valorPrato,
                    tipoBalanco: 1,
                    idPrato: this.pratoEscolhido.idPrato
                }
            }
            else if (this.valorSaida) {
                this.balanco = { 
                    valor: this.valorSaida,
                    tipoBalanco: 2,
                    idPrato: null
                }
            }

            this.criarBalanco();
        },

        cancelar() {
            this.prato = {
                nomePrato: "",
                descricaoPrato: "",
                valorPrato: 0,
                idCategoriaPrato: 1
            }

            this.showModel = false
        },

        editarPrato(prato) {
            this.prato = {...prato}
            this.showModel = true
        },

        salvarPrato() {
            if(!this.prato.idPrato) {
                this.adicionarPrato()
            }
            else {
                this.atualizarPrato()
            }
        },

        async listarPratos() {
            await axios.get(this.urlApi + "Prato")
                .then(response => {
                    if(response.status == 200) {
                        this.listaPratos = response.data
                    }
                })
        },

        async adicionarPrato() {
            await axios.post(this.urlApi + "Prato", this.prato).then(response => {
                if(response.status == 201) {
                    this.listarPratos()
                    this.showModel = false
                }
            })
        },

        async atualizarPrato() {
            await axios.put(this.urlApi + `Prato/${this.prato.idPrato}`, this.prato).then(response => {
                if(response.status == 200) {
                    this.listarPratos()
                    this.showModel = false
                }
            })
        },

        async deletePrato(prato) {
            await axios.delete(this.urlApi + `Prato/${prato.idPrato}`)
                .then(response => {
                    if(response.status == 200) {
                        this.listarPratos()
                    }
                })
        },

        async listarBalanco() {
            await axios.get(this.urlApi + "Balanco")
                .then(response => {
                    if(response.status == 200) {
                        this.listaBalanco = response.data
                    }
                })
        },

        async criarBalanco() {
            try {
                await axios.post(this.urlApi + 'Balanco', this.balanco)
                    .then(response => {
                        if(response.status == 200) {
                            this.listarBalanco()
                            this.showRegistro = false
                        }
                    })
            } catch(error) {
                console.log(error)
            }
        }

    }
    
});

app.mount('#app');