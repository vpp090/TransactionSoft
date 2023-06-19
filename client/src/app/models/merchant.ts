import { Transaction } from "./transaction"

export interface Merchant {
    id: number
    name: string
    description: string
    email: string
    status: number
    totalTransactionSum: number
    transactions: Transaction[]
  }

  export class Merchant implements Merchant {}